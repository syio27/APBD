using ClientTripApi.Models;
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
    public class ClientController : ControllerBase
    {

        private s20703Context _context;

        public ClientController(s20703Context context)
        {
            _context = context;
        }

        [HttpDelete("{index}")]
        public async Task<IActionResult> DeleteClient(string index)
        {
            var context = new s20703Context();
            var client = new Client
            {
                IdClient = int.Parse(index)
            };
            var clientTrip = new ClientTrip()
            {
                IdClient = int.Parse(index)
            };
            context.Clients.Attach(client);
            context.ClientTrips.Attach(clientTrip);
            context.Entry(client).State = EntityState.Deleted;
            context.Entry(clientTrip).State = EntityState.Deleted;

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
