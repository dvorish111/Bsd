using DAL.IRepositorys;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class DonorRepository: IDonorRepository
    {
       CampainContext _context;

        public DonorRepository(CampainContext context)
        {
            _context = context;
        }

        public async Task<List<Donor>> GetAll()
        {
            return await _context.Donors.ToListAsync();
        }

        public async Task<Donor> GetById(int donorId)
        {
            return await _context.Donors.FirstOrDefaultAsync(c => c.Id == donorId);
        }

        public async Task Create(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
           await _context.SaveChangesAsync();
        }

        public async Task<int> Create_ReturnID(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
            Donor newDonor =await _context.Donors.OrderByDescending(d => d.Id).FirstOrDefaultAsync();
            return  newDonor.Id;
        }

        public async Task Update(Donor donor)
        {
            var existingDonor =await _context.Donors.FirstOrDefaultAsync(c => c.Id == donor.Id);
            if (existingDonor != null)
            {
                existingDonor.FirstName = donor.FirstName;
                existingDonor.LastName = donor.LastName;
                existingDonor.Email = donor.Email;
                existingDonor.City = donor.City;
                existingDonor.Phone = donor.Phone;
                existingDonor.ZipCode = donor.ZipCode;
                existingDonor.Street = donor.Street;
               await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int donorId)
        {
            var donor = _context.Donors.FirstOrDefault(c => c.Id == donorId);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
              await  _context.SaveChangesAsync();
            }
        }

        public async Task<List<Donor>> GetAllByCity(string city)
        {
            return await _context.Donors.Where(d => d.City == city.ToLower()).ToListAsync();
        }

        public async Task DeleteAllEntities()
        {
            // Select all entities from the table
            var entitiesToDelete =await _context.Donors.ToListAsync ();

            // Remove all selected entities
            _context.Donors.RemoveRange(entitiesToDelete);

            // Save changes to delete the entities
           await _context.SaveChangesAsync();
        }
    }
}
