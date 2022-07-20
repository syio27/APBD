using DoctorPatientAPI.Helpers;
using DoctorPatientAPI.Models;
using DoctorPatientAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientAPI.Services
{
    public interface IAccountService
    {
        public Task<TokenResponseDTO> LoginAccount(LoginRequest loginInput, MainDbContext _context, IConfiguration _configuration);
        public Task RegisterAccount(RegisterRequest loginRegister, MainDbContext _context);
    }

    public class AccountService : IAccountService
    {
        public async Task<TokenResponseDTO> LoginAccount(LoginRequest loginInput, MainDbContext _context, IConfiguration _configuration)
        {
            AppUser user = await _context.Users.Where(u => u.Login == loginInput.Login).FirstOrDefaultAsync();

            string passDb = user.Password;
            string currentHashPass = SecurityHelpers.GetHashedPasswordWithSalt(loginInput.Password, user.Salt);

            if (passDb != currentHashPass)
            {
                throw new ArgumentException("Account password is unknown");
            }

            Claim[] userclaim = new[] {
                    new Claim(ClaimTypes.Name, "Baglan"),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.Role, "admin")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            user.RefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return new TokenResponseDTO
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = user.RefreshToken
            };
        }

        public async Task RegisterAccount(RegisterRequest loginRegister, MainDbContext _context)
        {
            var hashedPasswordSalt = SecurityHelpers.GetHashedPasswordAndSalt(loginRegister.Password);

            var user = new AppUser
            {
                Login = loginRegister.Login,
                Password = hashedPasswordSalt.Item1,
                Salt = hashedPasswordSalt.Item2,
                RefreshToken = SecurityHelpers.GenerateRefreshToken(),
                RefreshTokenExp = DateTime.Now.AddDays(1)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<TokenResponseDTO> GetRefreshToken(string token, RefreshTokenRequest refreshToken, MainDbContext _context, IConfiguration _configuration)
        {
            AppUser user = await _context.Users.Where(u => u.RefreshToken == refreshToken.RefreshToken).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            if (user.RefreshTokenExp < DateTime.Now)
            {
                throw new SecurityTokenException("Refresh token expired");
            }

            var login = SecurityHelpers.GetUserIdFromAccessToken(token.Replace("Bearer ", ""), _configuration["SecretKey"]);

            Claim[] userclaim = new[] {
                    new Claim(ClaimTypes.Name, "Baglan"),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.Role, "admin")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            user.RefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return new TokenResponseDTO
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                RefreshToken = user.RefreshToken
            };
        }
    }
}
