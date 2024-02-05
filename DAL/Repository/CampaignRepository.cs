using DAL.IRepositorys;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CampaignRepository: ICampaignRepository
    {
         CampainContext _context;

        public CampaignRepository(CampainContext context)
        {
            _context = context;
        }

        public async Task<List<Campaign>> GetAll()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public async Task<Campaign> GetById(int campaignId)
        {
            return await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaignId);
        }

        public async Task Create(Campaign campaign)
        {
           await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Campaign campaign)
        {
            var existingCampaign =await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaign.Id);
            if (existingCampaign != null)
            {
                existingCampaign.Name = campaign.Name;
                existingCampaign.StartDate = campaign.StartDate;
                existingCampaign.Goul = campaign.Goul;
                existingCampaign.Duration = campaign.Duration;
              await  _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int campaignId)
        {
            var campaign =await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaignId);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
               await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAllEntities()
        {
            // Select all entities from the table
            var entitiesToDelete =await _context.Campaigns.ToListAsync();
           
            // Remove all selected entities
            _context.Campaigns.RemoveRange(entitiesToDelete);
           

            // Save changes to delete the entities
           await _context.SaveChangesAsync();
            Campaign campaign = new Campaign();
            campaign.Id = 1;
            campaign.Name = "OOOO";
            campaign.Goul = 00000;
            campaign.StartDate= DateTime.Now;
            campaign.Duration =DateTime.Now.AddMonths(3);
            Create(campaign);
          await  _context.SaveChangesAsync();
        }

    }
}
