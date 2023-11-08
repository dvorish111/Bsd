using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace DAL.Repositories
{
    public class DonationRepository
    {
        private readonly CampainContext _dbContext;

        public DonationRepository(CampainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Donation GetDonationById(int donationId)
        {
            return _dbContext.Donations.FirstOrDefault(d => d.Id == donationId);
        }

        public List<Donation> GetAllDonations()
        {
            return _dbContext.Donations.ToList();
        }

        public void AddDonation(Donation donation)
        {
            _dbContext.Donations.Add(donation);
            _dbContext.SaveChanges();
        }

        public void UpdateDonation(Donation donation)
        {
            _dbContext.Donations.Update(donation);
            _dbContext.SaveChanges();
        }

        public void DeleteDonation(Donation donation)
        {
            _dbContext.Donations.Remove(donation);
            _dbContext.SaveChanges();
        }
    }
}
