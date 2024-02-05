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

        public async Task Create(DonorDTO donor)
        {
           await donorRepository.Create(mapper.Map<Donor>(donor));

           
        }

        public async Task<int> Create(DonorAllDTO donorAllDTO)
        {
            int idNewDonor =await donorRepository.Create_ReturnID(mapper.Map<Donor>(donorAllDTO));
            return  idNewDonor;
            
        }

        public async Task Delete(int id)
        {
           await donorRepository.Delete(id);
        }

        public async Task<List<DonorDTO>> GetAll()
        {
            List<Donor> donors =await donorRepository.GetAll();
            return  mapper.Map < List<DonorDTO>>(donors);
           
        }

        public async Task<List<DonorDTO>> GetAllByCity(string city)
        {
            return  mapper.Map<List<DonorDTO>>(await donorRepository.GetAllByCity(city));
        }

        public async Task<DonorDTO> GetById(int id)
        {
            return  mapper.Map<DonorDTO>(await donorRepository.GetById(id));
        }

        public async Task Update(DonorDTO donor)
        {
           await donorRepository.Update(mapper.Map<Donor>(donor));
            
        }

        /*public void Update(DonorAllDTO donorAllDTO)
        {
            donorRepository.Update(mapper.Map<Donor>(donorAllDTO));
        }*/
        public async Task DeleteAllEntities()
        {
           await donorRepository.DeleteAllEntities();
        }
    }
}
