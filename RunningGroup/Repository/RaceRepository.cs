using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interface;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;
        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Race club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Race club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(c => c.Address.City == city).ToListAsync();
        }

        public async Task<Race> GetById(int id)
        {
            return await _context.Races.Include(a => a.Address).FirstOrDefaultAsync(r => r.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race club)
        {
            _context.Update(club);
            return Save();
        }
    }
}
