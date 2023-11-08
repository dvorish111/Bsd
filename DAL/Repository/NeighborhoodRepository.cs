using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class NeighborhoodRepository
    {
        private readonly CampainContext _context;

        public NeighborhoodRepository(CampainContext context)
        {
            _context = context;
        }

        public List<Neighborhood> GetAllNeighborhoods()
        {
            return _context.Neighborhoods.ToList();
        }

        public Neighborhood GetNeighborhoodById(int neighborhoodId)
        {
            return _context.Neighborhoods.FirstOrDefault(c => c.Id == neighborhoodId);
        }

        public void AddNeighborhood(Neighborhood neighborhood)
        {
            _context.Neighborhoods.Add(neighborhood);
            _context.SaveChanges();
        }

        public void UpdateNeighborhood(Neighborhood neighborhood)
        {
            var existingNeighborhood = _context.Neighborhoods.FirstOrDefault(c => c.Id == neighborhood.Id);
            if (existingNeighborhood != null)
            {
                existingNeighborhood.Name = neighborhood.Name;
               // existingNeighborhood.Donates = neighborhood.Donates;
                _context.SaveChanges();
            }
        }

        public void DeleteNeighborhood(int neighborhoodId)
        {
            var neighborhood = _context.Neighborhoods.FirstOrDefault(c => c.Id == neighborhoodId);
            if (neighborhood != null)
            {
                _context.Neighborhoods.Remove(neighborhood);
                _context.SaveChanges();
            }
        }
    }
}
