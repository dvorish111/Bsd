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
    public class NeighborhoodService : INeighborhoodService
    {
        INeighborhoodRepository neighborhoodRepository;
        IMapper mapper;
        public NeighborhoodService(INeighborhoodRepository neighborhoodRepository, IMapper mapper)
        {
           this. neighborhoodRepository = neighborhoodRepository;
           this. mapper = mapper;

        }

        public async Task Create(NeighborhoodDTO neighborhood)
        {
          await neighborhoodRepository.Create(mapper.Map<Neighborhood>(neighborhood));
            
        }

        public async Task Delete(int id)
        {
            await neighborhoodRepository.Delete(id);
        }

        public async Task DeleteAllEntities()
        {
            throw new NotImplementedException();
        }

        public async Task<List<NeighborhoodDTO>> GetAll()
        {
            List<Neighborhood> neighborhoods = await neighborhoodRepository.GetAll();
            return  mapper.Map<List<NeighborhoodDTO>>(neighborhoods);
          
        }

        public async Task< NeighborhoodDTO> GetById(int id)
        {
            return  mapper.Map<NeighborhoodDTO>(await neighborhoodRepository.GetById(id));
        }

        public async Task Update(NeighborhoodDTO neighborhood)
        {
          await  neighborhoodRepository.Update(mapper.Map<Neighborhood>(neighborhood));
           
        }
    }
}
