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
            this.donorRepository = donorRepository;
            this.mapper = mapper;

        }

        public void Create(DonorDTO donor)
        {
            donorRepository.Create(mapper.Map<Donor>(donor));
        }

        public void Create(DonorAllDTO donorAllDTO)
        {
            Donor donor = mapper.Map<Donor>(donorAllDTO);
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

        public List<DonorDTO> GetAllByCity(string city)
        {
            return mapper.Map<List<DonorDTO>>(donorRepository.GetAllByCity(city));
        }

        public DonorDTO GetById(int id)
        {
            return mapper.Map<DonorDTO>(donorRepository.GetById(id));
        }

        public void Update(DonorDTO donor)
        {
            donorRepository.Update(mapper.Map<Donor>(donor));
            
        }

        /*public void Update(DonorAllDTO donorAllDTO)
        {
            donorRepository.Update(mapper.Map<Donor>(donorAllDTO));
        }*/
        public void DeleteAllEntities()
        {
            donorRepository.DeleteAllEntities();
        }
    }
}
