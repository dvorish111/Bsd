using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_AppService.IServeces;
using Common;
using DAL.IRepositorys;

namespace BL_AppService.Services
{
    public class CampaignService: ICampaignService
    {
        private readonly ICampaignRepository campaignRepository;

        public CampaignService(ICampaignRepository repository)
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
