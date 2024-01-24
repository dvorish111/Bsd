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
            return _context.Donations.Include(d => d.IdDonorNavigation).Include(d => d.IdDonatedNavigation.IdNeighborhoodNavigation).Include(d => d.IdDonatedNavigation.IdStatusNavigation).Include(d => d.IdDonatedNavigation).ToList();
        }

        public List<Donation> GetAllDonationsByDonated(int IdDonated)
        {
            return _context.Donations.Include(d => d.IdDonorNavigation).Include(d => d.IdDonatedNavigation.IdNeighborhoodNavigation).Include(d => d.IdDonatedNavigation.IdStatusNavigation).Include(d => d.IdDonatedNavigation).Where(d=>d.IdDonated==IdDonated).ToList();
        }

        public List<int> GetAllSumDonationsByDonated()
        {
            var donorIds = _context.Donates.Select(d => d.Id).OrderBy(id=>id).ToList();
            var donationAmounts = new List<int>();

            foreach (var donorId in donorIds)
            {
                var sumDonations = 0;
                 sumDonations = _context.Donations.Where(d => d.IdDonated == donorId).Sum(d => d.Amount);
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
            donation.Date=DateTime.Now;
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
                existingDonation.Date = donation.Date;
              
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

        public void DeleteAllEntities()
        {
            // Select all entities from the table
            var entitiesToDelete = _context.Donations.ToList();

            // Remove all selected entities
            _context.Donations.RemoveRange(entitiesToDelete);

            // Save changes to delete the entities
            _context.SaveChanges();
        }

        public List<Donation> GetAllFullDetails()
        {
            return _context.Donations.Include(d => d.IdDonorNavigation).Include(d => d.IdNeighborhoodNavigation).Include(d => d.IdDonatedNavigation.IdStatusNavigation).Include(d => d.IdDonatedNavigation).ToList();
        }
    }
}
