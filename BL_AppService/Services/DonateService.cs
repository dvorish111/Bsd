using Common;
using DAL.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_AppService.IServeces;
using Common;
using DAL.IRepositorys;
using DAL.Models;
using AutoMapper;

namespace BL_AppService.Services
{
    public class DonateService: IDonateService
    {
         IDonateRepository donateRepository;
        IMapper mapper;
        public DonateService(IDonateRepository repository, IMapper mapper)
        {
            donateRepository = repository;
            mapper = mapper;
        }

        public void Create(Donate donate)
        {
            donateRepository.Create(donate);
        }

        public void Delete(int id)
        {
            donateRepository.Delete(id);
        }

        public List<DonateDTO> GetAll()
        {
            List<Donate> donates = donateRepository.GetAll();
            return mapper.Map<List<DonateDTO>>(donates);

        }

        public DonateDTO GetById(int id)
        {
          
            return mapper.Map<DonateDTO>(donateRepository.GetById(id));
          
        }

        public void Update(Donate donate)
        {
            donateRepository.Update(donate);
        }
    }
}
