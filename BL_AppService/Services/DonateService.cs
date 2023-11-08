using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_AppService.Services
{
    public class DonateService
    {
        private readonly IDonateRepository campaignRepository;

        public DonateRepository(ICampaignRepository repository)
        {
            campaignRepository = repository;
        }
        public void CreateCampaign(CampaignDTO campaign)
        {
            campaignRepository.Create(campaign);
        }

        public CampaignDTO GetCampaignById(int id)
        {
            return campaignRepository.GetById(id);
        }

        public void UpdateCampaign(CampaignDTO campaign)
        {
            campaignRepository.Update(campaign);
        }
        public void DeleteCampaign(int id)
        {
            campaignRepository.Delete(id);
        }

    }
}
