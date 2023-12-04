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

        public List<int> GetAllSumDonationsByDonated()
        {
            var donorIds = _context.Donations.Select(d => d.IdDonated).Distinct().ToList();
            var donationAmounts = new List<int>();

            foreach (var donorId in donorIds)
            {
                var sumDonations = _context.Donations.Where(d => d.IdDonated == donorId).Sum(d => d.Amount);
                donationAmounts.Add(sumDonations);
            }

            return donationAmounts;
        }

        public int GetSumDonationsByDonated(int IdDonated)
        {
          return _context.Donations.Where(d=>d.IdDonated== IdDonated).Sum(d=>d.Amount);
        }
        public int GetSumDonation()
        {
            return _context.Donations.Sum(s => s.Amount);
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
