using DAL.IRepositorys;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class DonateRepository:IDonateRepository
    {
         CampainContext _context;

        public DonateRepository(CampainContext context)
        {
            _context = context;
        }

        public List<Donate> GetAll()
        {
            return _context.Donates.Include(d => d.IdNeighborhoodNavigation).ToList();
        }
        public List<Donate> GetAllByNumOfChildren(int to)
        {
            int from = to-5;            
            return _context.Donates.Where(d=>d.NumChildren>=from&&d.NumChildren<=to).Include(d => d.IdNeighborhoodNavigation).ToList();
        }
         public List<Donate> GetAllByStatus(int id)
        {
            return _context.Donates.Where(d=>d.IdStatus==id).Include(d => d.IdNeighborhoodNavigation).ToList();
        }
         public List<Donate> GetAllByNeeded(double needed)
        {
            double from = needed-500;
            if (needed == 10000) {
                from = 2000;
            }
            return _context.Donates.Where(d => d.Needed >= from && d.Needed <= needed).Include(d => d.IdNeighborhoodNavigation).ToList();
        }
        // public List<Donate> GetAllByGoul()
        //{
        //    return _context.Donates.ToList();
        //}

        public Donate GetByTaz(int donateTaz)
        {
            return _context.Donates.Include(d => d.IdNeighborhoodNavigation).FirstOrDefault(d => d.ParentTaz == donateTaz);
        }


        public void Create(Donate donate)
        {
            _context.Donates.Add(donate);
            _context.SaveChanges();
        }

        public void Update(Donate donate)
        {
            var existingDonate = _context.Donates.FirstOrDefault(d => d.ParentTaz == donate.ParentTaz);
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


        public void Delete(int donateId)
        {
            var donate = _context.Donates.FirstOrDefault(d => d.Id == donateId);
            if (donate != null)
            {
                _context.Donates.Remove(donate);
                _context.SaveChanges();
            }
        }

        public Donate GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetNumChildren()
        {          
            return _context.Donates.Sum(s => s.NumChildren);
        }
        public int GetNumFamily()
        {
            return _context.Donates.Count();
        }
    }
}