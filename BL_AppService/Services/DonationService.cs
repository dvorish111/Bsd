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
    public class DonationService : IDonationService
    {
        IDonationRepository donationRepository;
            IMapper mapper;
        public DonationService(IDonationRepository repository, IMapper mapper)
        {
            donationRepository = repository;
            this.mapper = mapper;
            

        }

        public void Create(DonationDTO donationDTO)
        {
            donationRepository.Create(mapper.Map<Donation>(donationDTO));

        }

        public void Delete(int id)
        {
            donationRepository.Delete(id);
        }

        public List<DonationDTO> GetAll()
        {
            List<Donation> donations = donationRepository.GetAll();
            return mapper.Map<List<DonationDTO>>(donations);
         
        }

        public DonationDTO GetByTaz(int id)
        {
            return mapper.Map<DonationDTO>(donationRepository.GetById(id));

        }

        public void Update(DonationDTO donationDTO)
        {          
            donationRepository.Update(mapper.Map<Donation>(donationDTO));
        }
    }
}
