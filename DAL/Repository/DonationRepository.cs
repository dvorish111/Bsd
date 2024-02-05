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

        public async Task<Donation> GetById(int donationId)
        {
            return await _context.Donations.FirstOrDefaultAsync(d => d.Id == donationId);
        }

        public async Task<List<Donation>> GetAll()
        {
            return await _context.Donations.Include(d => d.IdDonorNavigation).Include(d => d.IdNeighborhoodNavigation).Include(d => d.IdDonatedNavigation.IdNeighborhoodNavigation).Include(d => d.IdDonatedNavigation.IdStatusNavigation).Include(d => d.IdDonatedNavigation).ToListAsync();
        }

        public async Task<List<Donation>> GetAllDonationsByDonated(int IdDonated)
        {
            return await _context.Donations.Include(d => d.IdDonorNavigation).Include(d => d.IdDonatedNavigation.IdNeighborhoodNavigation).Include(d => d.IdDonatedNavigation.IdStatusNavigation).Include(d => d.IdDonatedNavigation).Where(d=>d.IdDonated==IdDonated).ToListAsync();
        }

        public async Task<List<int>> GetAllSumDonationsByDonated()
        {
            var donorIds =await  _context.Donates.Select(d => d.Id).OrderBy(id=>id).ToListAsync();
            var donationAmounts = new List<int>();

            foreach (var donorId in donorIds)
            {
                var sumDonations = 0;
                 sumDonations =await  _context.Donations.Where(d => d.IdDonated == donorId).SumAsync(d => d.Amount);
                donationAmounts.Add(sumDonations);
            }

            return donationAmounts;
        }

        public async Task<int> GetSumDonationsByDonated(int IdDonated)
        {
          return await  _context.Donations.Where(d=>d.IdDonated== IdDonated).SumAsync(d=>d.Amount);
        }
        public async Task<int> GetSumDonation()
        {
            return await _context.Donations.SumAsync(s => s.Amount);
        }

        public async Task Create(Donation donation)
                    {
            donation.Date=DateTime.Now;
            _context.Donations.Add(donation);
           await  _context.SaveChangesAsync();
        }

        public async Task Update(Donation donation)
        {
            var existingDonation =await  _context.Donations.FirstOrDefaultAsync(c => c.Id == donation.Id);
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
              
               await  _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int donorId)
        {
            var donation =await  _context.Donations.FirstOrDefaultAsync(c => c.Id == donorId);
            if (donation != null)
            {
               _context.Donations.Remove(donation);
               await  _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAllEntities()
        {
            // Select all entities from the table
            var entitiesToDelete =await  _context.Donations.ToListAsync();

            // Remove all selected entities
            _context.Donations.RemoveRange(entitiesToDelete);

            // Save changes to delete the entities
            await _context.SaveChangesAsync();
        }

        public async Task<List<Donation>> GetAllFullDetails()
        {
            return await _context.Donations.Include(d => d.IdDonorNavigation).Include(d => d.IdNeighborhoodNavigation).Include(d => d.IdDonatedNavigation.IdStatusNavigation).Include(d => d.IdDonatedNavigation).ToListAsync();
        }
    }
}
