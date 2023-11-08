using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class DonorRepository
    {
        private readonly CampainContext _context;

        public DonorRepository(CampainContext context)
        {
            _context = context;
        }

        public List<Donor> GetAllDonors()
        {
            return _context.Donors.ToList();
        }

        public Donor GetDonorById(int donorId)
        {
            return _context.Donors.FirstOrDefault(c => c.Id == donorId);
        }

        public void AddDonor(Donor donor)
        {
            _context.Donors.Add(donor);
            _context.SaveChanges();
        }

        public void UpdateDonor(Donor donor)
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

        public void DeleteDonor(int donorId)
        {
            var donor = _context.Donors.FirstOrDefault(c => c.Id == donorId);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                _context.SaveChanges();
            }
        }
    }
}
