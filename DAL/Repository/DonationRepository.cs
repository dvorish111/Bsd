using System;
using System.Collections.Generic;
using System.Linq;
using DAL.IRepositorys;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DonationRepository: IDonationRepository
    {
         CampainContext _context;

        public DonationRepository(CampainContext context)
        {
            _context = context;
        }

        public Donation GetById(int donationId)
        {
            return _context.Donations.FirstOrDefault(d => d.Id == donationId);
        }

        public List<Donation> GetAll()
        {
            return _context.Donations.ToList();
        }

        public void Create(Donation donation)
        {
            _context.Donations.Add(donation);
            _context.SaveChanges();
        }

        public void Update(Donation donation)
        {
            var existingDonation = _context.Donations.FirstOrDefault(c => c.Id == donation.Id);
            if (existingDonation != null)
            {
                existingDonation.Quetel = donation.Quetel;
                existingDonation.NumPayments = donation.NumPayments;
                existingDonation.IsAnonymous = donation.IsAnonymous;
                existingDonation.Amount = donation.Amount;
                existingDonation.IdDonated = donation.IdDonated;
                existingDonation.IdDonor = donation.IdDonor;
                existingDonation.Dedication = donation.Dedication;
              
                _context.SaveChanges();
            }
        }

        public void Delete(int donorId)
        {
            var donation = _context.Donations.FirstOrDefault(c => c.Id == donorId);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
                _context.SaveChanges();
            }
        }
    }
}
