using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Data;
using MovieApp.Shared.DTOs;
using MovieApp.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Server.Services
{
    public class MoviesDbService : IMoviesDbService
    {
        private ApplicationDbContext _context;

        public MoviesDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie.Id;
        }

        public async Task<Movie> GetMovie(int movieId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(id => id.Id == movieId);
            if (movie == null) 
            {
                throw new System.ArgumentNullException();
            }
            return movie;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<int> DeleteMovie(int movieId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(id => id.Id == movieId);
            if (movie == null)
            {
                throw new System.ArgumentNullException();
            }

            _context.Remove(movie);
            await _context.SaveChangesAsync();
            return movie.Id;
        }

        //public async Task<int> UpdateMovie(Movie inputMovie, int movieId)
        //{
        //    var movie = new Movie
        //    {
        //        Id = movieId,
        //        Title = inputMovie.Title,
        //        Summary = inputMovie.Summary,
        //        InTheaters = inputMovie.InTheaters,
        //        Trailer = inputMovie.Trailer,
        //        ReleaseDate = inputMovie.ReleaseDate,
        //        Poster = inputMovie.Poster
        //    };

        //    _context.Attach(movie).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return movie.Id;
        //}
        public async Task<int> UpdateMovie(Movie inputMovie)
        {
            _context.Attach(inputMovie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return inputMovie.Id;
        }
    }
}
