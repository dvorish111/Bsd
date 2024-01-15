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

        public void Create(NeighborhoodDTO neighborhood)
        {
            neighborhoodRepository.Create(mapper.Map<Neighborhood>(neighborhood));
            
        }

        public void Delete(int id)
        {
            neighborhoodRepository.Delete(id);
        }

        public void DeleteAllEntities()
        {
            throw new NotImplementedException();
        }

        public List<NeighborhoodDTO> GetAll()
        {
            List<Neighborhood> neighborhoods = neighborhoodRepository.GetAll();
            return mapper.Map<List<NeighborhoodDTO>>(neighborhoods);
          
        }

        public NeighborhoodDTO GetById(int id)
        {
            return mapper.Map<NeighborhoodDTO>(neighborhoodRepository.GetById(id));
        }

        public void Update(NeighborhoodDTO neighborhood)
        {
            neighborhoodRepository.Update(mapper.Map<Neighborhood>(neighborhood));
           
        }
    }
}
