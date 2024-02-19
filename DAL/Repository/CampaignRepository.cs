using DAL.IRepositorys;
using DAL.Models;
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

        public List<Campaign> GetAll()
        {
            return _context.Campaigns.ToList();
        }

        public Campaign GetById(int campaignId)
        {
            return _context.Campaigns.FirstOrDefault(c => c.Id == campaignId);
        }

        public void Create(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
            _context.SaveChanges();
        }

        public void Update(Campaign campaign)
        {
            var existingCampaign = _context.Campaigns.FirstOrDefault(c => c.Id == campaign.Id);
            if (existingCampaign != null)
            {
                existingCampaign.Name = campaign.Name;
                existingCampaign.StartDate = campaign.StartDate;
                existingCampaign.Goul = campaign.Goul;
                existingCampaign.EndDate = campaign.EndDate;
                _context.SaveChanges();
            }
        }

        public void Delete(int campaignId)
        {
            var campaign = _context.Campaigns.FirstOrDefault(c => c.Id == campaignId);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
                _context.SaveChanges();
            }
        }
        public void DeleteAllEntities()
        {
            // Select all entities from the table
            var entitiesToDelete = _context.Campaigns.ToList();
           
            // Remove all selected entities
            _context.Campaigns.RemoveRange(entitiesToDelete);
           

            // Save changes to delete the entities
            _context.SaveChanges();
            Campaign campaign = new Campaign();
            campaign.Id = 1;
            campaign.Name = "OOOO";
            campaign.Goul = 00000;
            campaign.StartDate= DateTime.Now;
            campaign.EndDate = DateTime.Now;
            Create(campaign);
            _context.SaveChanges();
        }

    }
}
