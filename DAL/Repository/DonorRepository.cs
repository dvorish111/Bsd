using DAL.IRepositorys;
using DAL.Models;
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

        public List<Donor> GetAll()
        {
            return _context.Donors.ToList();
        }

        public Donor GetById(int donorId)
        {
            return _context.Donors.FirstOrDefault(c => c.Id == donorId);
        }

        public void Create(Donor donor)
        {
            _context.Donors.Add(donor);
            _context.SaveChanges();
        }

        public int Create_ReturnID(Donor donor)
        {
            _context.Donors.Add(donor);
            _context.SaveChanges();
            Donor newDonor = _context.Donors.OrderByDescending(d => d.Id).FirstOrDefault();
            return newDonor.Id;
        }

        public void Update(Donor donor)
        {
            var existingDonor = _context.Donors.FirstOrDefault(c => c.Id == donor.Id);
            if (existingDonor != null)
            {
                existingDonor.FirstName = donor.FirstName;
                existingDonor.LastName = donor.LastName;
                existingDonor.Email = donor.Email;
                existingDonor.City = donor.City;
                existingDonor.Phone = donor.Phone;
                existingDonor.ZipCode = donor.ZipCode;
                existingDonor.Street = donor.Street;
                _context.SaveChanges();
            }
        }

        public void Delete(int donorId)
        {
            var donor = _context.Donors.FirstOrDefault(c => c.Id == donorId);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                _context.SaveChanges();
            }
        }

        public List<Donor> GetAllByCity(string city)
        {
            return _context.Donors.Where(d => d.City == city.ToLower()).ToList();
        }

        public void DeleteAllEntities()
        {
            // Select all entities from the table
            var entitiesToDelete = _context.Donors.ToList();

            // Remove all selected entities
            _context.Donors.RemoveRange(entitiesToDelete);

            // Save changes to delete the entities
            _context.SaveChanges();
        }
    }
}
