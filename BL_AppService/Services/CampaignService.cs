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
           this.campaignRepository = repository;
           this.mapper = mapper;    
        }

        public async Task Create(CampaignDTO campaign)
        { 
            await campaignRepository.Create(mapper.Map<Campaign>(campaign));

        }

        public async Task Delete(int id)
        {
           await campaignRepository.Delete(id);
        }

        public async Task<List<CampaignDTO>> GetAll()
        {
            List<Campaign> campaigns = await campaignRepository.GetAll();
            return  mapper.Map <List<CampaignDTO>> (campaigns);          
        }

        public async Task<CampaignDTO> GetById(int id)
        {
             return  mapper.Map<CampaignDTO>(await campaignRepository.GetById(id));
        }

        public async Task Update(CampaignDTO campaign)
        {
            await campaignRepository.Update(mapper.Map<Campaign>(campaign));
           
        }


        public async Task  DeleteAllEntities()
        {
            await campaignRepository.DeleteAllEntities();
        }

    }
}
