using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Server.Services;
using MovieApp.Shared.DTOs;
using MovieApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MovieApp.Server.Controllers
{
    [Authorize]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesDbService _dbService;

        public MoviesController(ILogger<MoviesController> logger, IMoviesDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            return await _dbService.GetMovies();
        }

        [HttpGet("{index}")]
        public async Task<ActionResult<Movie>> Get(string index)
        {
            try
            {
                return await _dbService.GetMovie(int.Parse(index));
            }
            catch (Exception)
            {
                return NotFound("movie doesnt exist");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Movie movie)
        {
            return await _dbService.AddMovie(movie);
        }

        //[HttpPut("{index}")]
        //public async Task<ActionResult<int>> Put([FromBody]Movie movie, string index)
        //{
        //    return await _dbService.UpdateMovie(movie, int.Parse(index));
        //}

        [HttpPut]
        public async Task<ActionResult<int>> Put([FromBody] Movie movie)
        {
            return await _dbService.UpdateMovie(movie);
        }

        [HttpDelete("{index}")]
        public async Task<ActionResult<int>> Delete(string index)
        {
            try
            {
                return await _dbService.DeleteMovie(int.Parse(index));
            }
            catch (Exception)
            {
                return NotFound("movie doesnt exist");
            }
        }
    }
}
