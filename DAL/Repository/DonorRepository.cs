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
    }
}
