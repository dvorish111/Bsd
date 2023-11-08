using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class DonateRepository
    {
        private readonly CampainContext _context;

        public DonateRepository(CampainContext context)
        {
            _context = context;
        }

        public List<Donate> GetAllDonates()
        {
            return _context.Donates.ToList();
        }

        public Donate GetDonateById(int donateId)
        {
            return _context.Donates.FirstOrDefault(d => d.Id == donateId);
        }

        public void AddDonate(Donate donate)
        {
            _context.Donates.Add(donate);
            _context.SaveChanges();
        }

        public void UpdateDonate(Donate donate)
        {
            var existingDonate = _context.Donates.FirstOrDefault(d => d.Id == donate.Id);
            if (existingDonate != null)
            {
                existingDonate.Name = donate.Name;
                existingDonate.NumChildren = donate.NumChildren;
                existingDonate.IdStatus = donate.IdStatus;
                existingDonate.Street = donate.Street;
                existingDonate.Needed = donate.Needed;
                existingDonate.NumberBuilding = donate.NumberBuilding;
                existingDonate.IdNeighborhood = donate.IdNeighborhood;
                _context.SaveChanges();
            }
        }


        public void DeleteDonate(int donateId)
        {
            var donate = _context.Donates.FirstOrDefault(d => d.Id == donateId);
            if (donate != null)
            {
                _context.Donates.Remove(donate);
                _context.SaveChanges();
            }
        }
    }
}