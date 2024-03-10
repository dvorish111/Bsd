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

        public async Task< List<Donate>> GetAll()
        {
            return await _context.Donates.Include(d => d.IdNeighborhoodNavigation).Include(d => d.IdStatusNavigation).ToListAsync();
        }
        public async Task<List<Donate>> GetAllByNumOfChildren(int to)
        {
            int from = to-5;            
            return await _context.Donates.Where(d=>d.NumChildren>=from&&d.NumChildren<=to).Include(d => d.IdNeighborhoodNavigation).ToListAsync();
        }
        public async Task<List<Donate>> GetAllByStatus(int id)
        {
            return await _context.Donates.Where(d=>d.IdStatus==id).Include(d => d.IdNeighborhoodNavigation).ToListAsync();
        }
        public async Task<List<Donate>> GetAllByNeeded(double needed)
        {
            double from = needed-500;
            if (needed == 10000) {
                from = 2000;
            }
            return await _context.Donates.Where(d => d.Needed >= from && d.Needed <= needed).Include(d => d.IdNeighborhoodNavigation).ToListAsync();
        }
        // public List<Donate> GetAllByGoul()
        //{
        //    return _context.Donates.ToList();
        //}

        public async Task<Donate>  GetByTaz(string donateTaz)
        {
            return await _context.Donates.Include(d => d.IdNeighborhoodNavigation).FirstOrDefaultAsync(d => d.ParentTaz == donateTaz);
        }


        public async Task Create(Donate donate)
        {
            //Donate donate1 = new() { ParentTaz = 0, Name = "", NumChildren = 0, IdStatus = 0, Street = "", Needed = 0, NumberBuilding = 0, IdNeighborhood = 0};

        //donate.Id = 14;
          await  _context.Donates.AddAsync(donate);
          await _context.SaveChangesAsync();
        }

        public async Task Update(Donate donate)
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
                existingDonate.Raised = donate.Raised;
                await _context.SaveChangesAsync();
            }
        }
        public void UpdateRaised(int? id, int raised)
        {
            var existingDonate = _context.Donates.FirstOrDefault(d => d.Id == id);
            if (existingDonate != null)
            {
                existingDonate.Raised = raised;
            }
            _context.SaveChanges();
        }


        public async Task Delete(int donateId)
        {
            var donate = _context.Donates.FirstOrDefault(d => d.Id == donateId);
            if (donate != null)
            {
               _context.Donates.Remove(donate);
              await  _context.SaveChangesAsync();
            }

        }

        public async Task<Donate> GetById(int id)
        {

            return await _context.Donates.Include(d => d.IdNeighborhoodNavigation).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> GetNumChildren()
        {          
            return await _context.Donates.SumAsync(s => s.NumChildren);
        }
        public async Task<int> GetNumFamily()
        {
            return await _context.Donates.CountAsync();
        }

        public async Task CraeteDonatesByExcel(List<Donate> donates) {

            // Add the records to the table
            foreach (var donate in donates)
            {
           await _context.Donates.AddAsync(donate);
                await _context.SaveChangesAsync();
            }
          

        }

        public async Task DeleteAllEntities()
        {
            // Select all entities from the table
            var entitiesToDelete =await _context.Donates.ToListAsync();

            // Remove all selected entities
           _context.Donates.RemoveRange(entitiesToDelete);

            // Save changes to delete the entities
            await _context.SaveChangesAsync();
        }

    }
}