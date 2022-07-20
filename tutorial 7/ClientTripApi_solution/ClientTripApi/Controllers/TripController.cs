using ClientTripApi.Models;
using ClientTripApi.Models.DTOs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTripApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private s20703Context _context;

        public TripController(s20703Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var context = new s20703Context();
            var trips = await context.Trips
                                            .Include(t => t.CountryTrips).ThenInclude(co => co.IdCountryNavigation)
                                            .Include(t => t.ClientTrips).ThenInclude(cl => cl.IdClientNavigation)
                                            .Select(t => new 
                                            {
                                                Name = t.Name,
                                                Description = t.Description,
                                                DateFrom = t.DateFrom,
                                                DateTo = t.DateTo,
                                                MaxPeople = t.MaxPeople,
                                                Countries = t.CountryTrips.Select(x => new { Name = x.IdCountryNavigation.Name }),
                                                Clients = t.ClientTrips.Select(x => new 
                                                {
                                                    FirstName = x.IdClientNavigation.FirstName,
                                                    LastName = x.IdClientNavigation.LastName
                                                })
                                            })
                                            .OrderBy(t => t.DateFrom)
                                            .ToListAsync();

            return Ok(trips);
        }
    }
}
