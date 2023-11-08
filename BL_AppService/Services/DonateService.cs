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
using Microsoft.EntityFrameworkCore;

namespace BL_AppService.Services
{
    public class DonateService : IDonateService
    {
        IDonateRepository donateRepository;
        IMapper mapper;
        public DonateService(IDonateRepository repository, IMapper mapper)
        {
            donateRepository = repository;
            mapper = mapper;
        }

        public void Create(DonateDTO donateDTO)
        {
            donateRepository.Create(mapper.Map<Donate>(donateDTO));

        }

        public void Delete(int id)
        {
            donateRepository.Delete(id);
        }

        public List<DonateDTO> GetAll()
        {
            return mapper.Map<List<DonateDTO>>(donateRepository.GetAll());

        }
        public List<DonateDTO> GetAllByNumOfChildren(int from, int to)
        {
            return mapper.Map<List<DonateDTO>>(donateRepository.GetAllByNumOfChildren(from, to));
        }
        public List<DonateDTO> GetAllByStatus(int id)
        {
            return mapper.Map<List<DonateDTO>>(donateRepository.GetAllByStatus(id));
        }
        public List<DonateDTO> GetAllByNeeded(double id)
        {
            return mapper.Map<List<DonateDTO>>(donateRepository.GetAllByNeeded(id));
        }
        // public List<Donate> GetAllByGoul()
        //{
        //    return _context.Donates.ToList();
        //}

        public DonateDTO GetById(int id)
        {

            return mapper.Map<DonateDTO>(donateRepository.GetById(id));

        }

        public void Update(DonateDTO donateDTO)
        {                  
            donateRepository.Update(mapper.Map<Donate>(donateDTO));
        }
    }
}
