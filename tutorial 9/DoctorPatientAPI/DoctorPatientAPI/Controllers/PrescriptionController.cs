using DoctorPatientAPI.Models;
using DoctorPatientAPI.Models.DTOs.Response;
using DoctorPatientAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorPatientAPI.Controllers
{
    [Authorize]
    [Route("api/prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private MainDbContext _context;
        private readonly IConfiguration _configuration;
        public PrescriptionController(MainDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("{index}")]
        public async Task<IActionResult> GetPrescription(string index)
        {
            var prescription = await new PrescriptionDbService().GetPrescription(_context, index);
            return Ok(prescription);
        }
    }
}
