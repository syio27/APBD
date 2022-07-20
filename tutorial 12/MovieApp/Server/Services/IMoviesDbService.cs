using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Shared.DTOs;
using MovieApp.Shared.Models;

namespace MovieApp.Server.Services
{
    public interface IMoviesDbService
    {
        Task<List<Movie>> GetMovies();
        Task<int> AddMovie(Movie movie);
        Task<Movie> GetMovie(int movieId);
        Task<int> DeleteMovie(int movieID);
        //Task<int> UpdateMovie(Movie movie, int movieId);
        Task<int> UpdateMovie(Movie movie);
    }
}
