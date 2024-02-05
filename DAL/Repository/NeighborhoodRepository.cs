using DAL.IRepositorys;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class NeighborhoodRepository: INeighborhoodRepository
    {
         CampainContext _context;

        public NeighborhoodRepository(CampainContext context)
        {
            _context = context;
        }

        public async Task<List<Neighborhood>> GetAll()
        {
            return await _context.Neighborhoods.ToListAsync();
        }

        public async Task<Neighborhood> GetById(int neighborhoodId)
        {
            return await _context.Neighborhoods.FirstOrDefaultAsync(c => c.Id == neighborhoodId);
        }

        public async Task Create(Neighborhood neighborhood)
        {
            int id = _context.Neighborhoods.Count() + 1;
          await  _context.Neighborhoods.AddAsync(neighborhood);
            await _context.SaveChangesAsync();

        }

        public async Task Update(Neighborhood neighborhood)
        {
            var existingNeighborhood =await _context.Neighborhoods.FirstOrDefaultAsync(c => c.Id == neighborhood.Id);
            if (existingNeighborhood != null)
            {
                existingNeighborhood.Name = neighborhood.Name;
                // existingNeighborhood.Donates = neighborhood.Donates;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int neighborhoodId)
        {
            var neighborhood = _context.Neighborhoods.FirstOrDefault(c => c.Id == neighborhoodId);
            if (neighborhood != null)
            {
                _context.Neighborhoods.Remove(neighborhood);
              await  _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAllEntities()
        {
            throw new NotImplementedException();
        }
    }
}
