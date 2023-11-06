using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CampaignRepository
    {
        private readonly CampainContext _context;

        public CampaignRepository(CampainContext context)
        {
            _context = context;
        }

        public List<Campaign> GetAllCampaigns()
        {
            return _context.Campaigns.ToList();
        }

        public Campaign GetCampaignById(int campaignId)
        {
            return _context.Campaigns.FirstOrDefault(c => c.Id == campaignId);
        }

        public void AddCampaign(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
            _context.SaveChanges();
        }

        public void UpdateCampaign(Campaign campaign)
        {
            var existingCampaign = _context.Campaigns.FirstOrDefault(c => c.Id == campaign.Id);
            if (existingCampaign != null)
            {
                existingCampaign.Name = campaign.Name;
                existingCampaign.StartDate = campaign.StartDate;
                existingCampaign.Goul = campaign.Goul;
                existingCampaign.Duration = campaign.Duration;
                _context.SaveChanges();
            }
        }

        public void DeleteCampaign(int campaignId)
        {
            var campaign = _context.Campaigns.FirstOrDefault(c => c.Id == campaignId);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
                _context.SaveChanges();
            }
        }
    }
}
