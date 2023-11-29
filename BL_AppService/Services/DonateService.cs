using Common;
using DAL.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_AppService.IServeces;
using DAL.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BL_AppService.Services
{
    public class DonateService : IDonateService
    {
        IDonateRepository donateRepository;
        IMapper mapper;
        public DonateService(IDonateRepository donateRepository, IMapper mapper)
        {
           this.donateRepository = donateRepository;
           this.mapper = mapper;
        }

        public void Create(DonateAllDTO donateAllDTO)
        {
            Donate donate = mapper.Map<Donate>(donateAllDTO);
            donateRepository.Create(donate);
/*            donateRepository.Create(mapper.Map<Donate>(donateAllDTO));
*/
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
        public List<DonateDTO> GetAllByNumOfChildren( int to)
        {
            return mapper.Map<List<DonateDTO>>(donateRepository.GetAllByNumOfChildren(to));
        }
        public List<DonateDTO> GetAllByStatus(int id)
        {
            return mapper.Map<List<DonateDTO>>(donateRepository.GetAllByStatus(id));
        }
        public List<DonateDTO> GetAllByNeeded(double needed)
        {
            return mapper.Map<List<DonateDTO>>(donateRepository.GetAllByNeeded(needed));
        }
        // public List<Donate> GetAllByGoul()
        //{
        //    return _context.Donates.ToList();
        //}

        public DonateDTO GetByTaz(int taz)
        {
           
            return mapper.Map<DonateDTO>(donateRepository.GetByTaz(taz));

        }

        public void Update(DonateAllDTO donateAllDTO)
        {                  
            donateRepository.Update(mapper.Map<Donate>(donateAllDTO));
        }

        public void Create(DonateDTO ObjToAdd)
        {
            throw new NotImplementedException();
        }

        public void Update(DonateDTO ObjToUpdate)
        {
            throw new NotImplementedException();
        }

        public DonateDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
