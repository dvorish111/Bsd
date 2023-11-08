using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL_AppService.IServeces;
using Common;
using DAL.IRepositorys;

namespace BL_AppService.Services
{
    public class CampaignService: ICampaignService
    {
        private readonly ICampaignRepository campaignRepository;
        IMapper mapper;
        public CampaignService(ICampaignRepository repository,IMapper mapper)
        {
            campaignRepository = repository;
            mapper = mapper;    
        }

        public void CreateCampaign(CampaignDTO campaign)
        {
          
            throw new NotImplementedException();
        }

        public void DeleteCampaign(int id)
        {
            throw new NotImplementedException();
        }

        public CampaignDTO GetCampaignById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCampaign(CampaignDTO campaign)
        {
            throw new NotImplementedException();
        }
        /* public void CreateCampaign(CampaignDTO campaign)
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
*/

    }
}
