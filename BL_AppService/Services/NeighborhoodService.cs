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
            neighborhoodRepository = neighborhoodRepository;
            mapper = mapper;

        }

        public void Create(Neighborhood neighborhood)
        {
            neighborhoodRepository.Create(neighborhood);
        }

        public void Delete(int id)
        {
            neighborhoodRepository.Delete(id);
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

        public void Update(Neighborhood neighborhood)
        {
            neighborhoodRepository.Update(neighborhood);
        }
    }
}
