using DAL.IRepositorys;
using DAL.Models;
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
            return _context.Donates.ToList();
        }
        public List<Donate> GetAllByNumOfChildren(int from,int to)
        {
            return _context.Donates.Where(d=>d.NumChildren>from&&d.NumChildren<to).ToList();
        }
         public List<Donate> GetAllByStatus(int id)
        {
            return _context.Donates.Where(d=>d.IdStatus==id).ToList();
        }
         public List<Donate> GetAllByNeeded(double needed)
        {
            return _context.Donates.Where(d=>d.Needed== needed).ToList();
        }
        // public List<Donate> GetAllByGoul()
        //{
        //    return _context.Donates.ToList();
        //}

        public Donate GetById(int donateId)
        {
            return _context.Donates.FirstOrDefault(d => d.Id == donateId);
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
    }
}