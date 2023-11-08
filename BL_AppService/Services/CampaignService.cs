using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL_AppService.IServeces;
using Common;
using DAL.IRepositorys;
using DAL.Models;

namespace BL_AppService.Services
{
    public class CampaignService: ICampaignService
    {
         ICampaignRepository campaignRepository;
        IMapper mapper;
        public CampaignService(ICampaignRepository repository,IMapper mapper)
        {
            campaignRepository = repository;
            mapper = mapper;    
        }

        public void Create(CampaignDTO campaign)
        {
            campaignRepository.Create(mapper.Map<Campaign>(campaign));

        }

        public void Delete(int id)
        {
            campaignRepository.Delete(id);
        }

        public List<CampaignDTO> GetAll()
        {
            List<Campaign> campaigns = campaignRepository.GetAll();
            return mapper.Map <List<CampaignDTO>> (campaigns);          
        }

        public CampaignDTO GetById(int id)
        {
             return mapper.Map<CampaignDTO>(campaignRepository.GetById(id));
        }

        public void Update(CampaignDTO campaign)
        {
            campaignRepository.Update(mapper.Map<Campaign>(campaign));
           
        }




    }
}
