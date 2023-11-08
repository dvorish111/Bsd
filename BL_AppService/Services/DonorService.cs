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
    public class DonorService : IDonorService
    {
        IDonorRepository donorRepository;
        IMapper mapper;
        public DonorService(IDonorRepository donorRepository, IMapper mapper)
        {
            donorRepository = donorRepository;
            mapper = mapper;

        }

        public void Create(Donor donor)
        {
            donorRepository.Create(donor);
        }

        public void Delete(int id)
        {
            donorRepository.Delete(id);
        }

        public List<DonorDTO> GetAll()
        {
            List<Donor> donors = donorRepository.GetAll();
            return  mapper.Map < List<DonorDTO>>(donors);
           
        }

        public DonorDTO GetById(int id)
        {
            return mapper.Map<DonorDTO>(donorRepository.GetById(id));
        }

        public void Update(Donor donor)
        {
            donorRepository.Update(donor);
        }
    }
}
