using DoctorPatientAPI.Helpers;
using DoctorPatientAPI.Models;
using DoctorPatientAPI.Models.DTOs;
using DoctorPatientAPI.Services;
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

namespace DoctorPatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private MainDbContext _context;
        private readonly IConfiguration _configuration;
        public AccountsController(MainDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginInput)
        {
            var token = new TokenResponseDTO();
            try
            {
                token = await new AccountService().LoginAccount(loginInput, _context, _configuration);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest loginRegister)
        {
            await new AccountService().RegisterAccount(loginRegister, _context);
            return StatusCode(204);
        }


        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromHeader(Name = "Authorization")] string token, RefreshTokenRequest refreshToken)
        {
            var refreshedToken = new TokenResponseDTO();
            refreshedToken = await new AccountService().GetRefreshToken(token, refreshToken, _context, _configuration);
            return Ok(refreshedToken);
        }
    }
}
