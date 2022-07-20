using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Data;
using MovieApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Server.Services
{
    public class ActorsDbService
    {
        private ApplicationDbContext _context;

        public ActorsDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MoviesActors>> GetActors()
        {
            return await _context.MoviesActors.ToListAsync();
        }

        public async Task<MoviesActors> GetActor(int actorId)
        {
            var actor = await _context.MoviesActors.FirstOrDefaultAsync(id => id.PersonId == actorId);
            if (actor == null)
            {
                throw new System.ArgumentNullException();
            }
            return actor;
        }

        public async Task<int> UpdateActor(MoviesActors actor)
        {
            _context.Attach(actor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return actor.PersonId;
        }

        public async Task<int> DeleteMovie(int actorId)
        {
            var actor = await _context.MoviesActors.FirstOrDefaultAsync(id => id.PersonId == actorId);
            if (actor == null)
            {
                throw new System.ArgumentNullException();
            }

            _context.Remove(actor);
            await _context.SaveChangesAsync();
            return actor.PersonId;
        }

        public async Task<int> AddMovie(MoviesActors actor)
        {
            _context.MoviesActors.Add(actor);
            await _context.SaveChangesAsync();
            return actor.PersonId;   
        }
    }
}
