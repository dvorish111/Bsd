using DAL.IRepositorys;
using DAL.Models;
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

        public List<Neighborhood> GetAll()
        {
            return _context.Neighborhoods.ToList();
        }

        public Neighborhood GetById(int neighborhoodId)
        {
            return _context.Neighborhoods.FirstOrDefault(c => c.Id == neighborhoodId);
        }

        public void Create(Neighborhood neighborhood)
        {
            int id = _context.Neighborhoods.Count() + 1;
            _context.Neighborhoods.Add(neighborhood);
            _context.SaveChanges();
        }

        public void Update(Neighborhood neighborhood)
        {
            var existingNeighborhood = _context.Neighborhoods.FirstOrDefault(c => c.Id == neighborhood.Id);
            if (existingNeighborhood != null)
            {
                existingNeighborhood.Name = neighborhood.Name;
               // existingNeighborhood.Donates = neighborhood.Donates;
                _context.SaveChanges();
            }
        }

        public void Delete(int neighborhoodId)
        {
            var neighborhood = _context.Neighborhoods.FirstOrDefault(c => c.Id == neighborhoodId);
            if (neighborhood != null)
            {
                _context.Neighborhoods.Remove(neighborhood);
                _context.SaveChanges();
            }
        }

        public void DeleteAllEntities()
        {
            throw new NotImplementedException();
        }
    }
}
