using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private IDatabaseService _dbService;
        public AnimalsController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetAnimals([FromQuery] string orderBy)
        {
            return Ok(_dbService.GetAnimals(orderBy));
        }

        [HttpPost]
        public IActionResult PostAnimal([FromBody] Animals animal)
        {
            if (_dbService.AddAnimal(animal) > 0)
            {
                return Ok("new Animal created");
            }
            else
                return NotFound();
        }

        [HttpPut("{idAnimal}")]
        public IActionResult PutAnimal([FromBody] Animals animals, int idAnimal)
        {
            if (_dbService.UpdateAnimal(animals, idAnimal) > 0)
            {
                return NoContent(); // resource updated successfully
            }
            else
                return NotFound();
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal(int idAnimal)
        {
            if (_dbService.DeleteAnimal(idAnimal) > 0)
            {
                return NoContent(); // resource deleted successfully
            }
            else
                return NotFound();
        }
    }
}
