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
using Microsoft.EntityFrameworkCore;

namespace BL_AppService.Services
{
    public class DonationService: IDonationService
    {
        IDonationRepository donationRepository;
            IMapper mapper;
        public DonationService(IDonationRepository repository, IMapper mapper)
        {
            donationRepository = repository;
            this.mapper = mapper;
            

        }

        public async Task Create(DonationAllDTO donationDTO)
        {
            await donationRepository.Create(mapper.Map<Donation>(donationDTO));

        }

        public async Task Delete(int id)
        {
           await donationRepository.Delete(id);
        }

        public async Task<List<DonationDTO>> GetAll()
        {
            List<Donation> donations =await donationRepository.GetAll();
            return  mapper.Map<List<DonationDTO>>(donations);
         
        }
        //public List<DonationDTO> GetAllByDonated(int IdDonated)
        //{
        //    List<Donation> donations = donationRepository.GetAllByDonated();
        //    return mapper.Map<List<DonationDTO>>(donations);
        //}
        public async Task<DonationDTO> GetById(int id)
        {
            return  mapper.Map<DonationDTO>(await donationRepository.GetById(id));

        }

        public async Task<int> GetSumDonation()
        {
            return await donationRepository.GetSumDonation();

        }

        public async Task<int> GetSumDonationsByDonated(int IdDonated)
        {
            return await donationRepository.GetSumDonationsByDonated(IdDonated);
        }

        public async Task< List<int>> GetAllSumDonationsByDonated()
        {
            return await donationRepository.GetAllSumDonationsByDonated();
        }
        public async Task Update(DonationDTO donationDTO)
        {          
           await donationRepository.Update(mapper.Map<Donation>(donationDTO));
        }
        public async Task DeleteAllEntities()
        {
           await donationRepository.DeleteAllEntities();
        }

        public async Task<List<DonationDTO>> GetAllDonationsByDonated(int IdDonated)
        {
            return  mapper.Map<List<DonationDTO>>(await donationRepository.GetAllDonationsByDonated(IdDonated));
        }
        public async Task<Stream> GetDonationsByExcel()
        {
            var data =await donationRepository.GetAllFullDetails();
            var csvContent = new StringBuilder();
            csvContent.AppendLine(" ID,Amount,Donated Name, Donated ParentTaz,Status,Needed,NumberBuilding,Neighborhood,Donor Name,Donor Email,Donor City,Donor Phone");
         //   csvContent.AppendLine("מספר תרומה, סכום תרומה, שם הנתרם, תז הנתרם, סטטוס הנתרם, כמה צריך, מספר בנין,שכונה, שם התורם , מייל התורם, עיר, טלפון התורם");
            foreach (var item in data)
            {
                csvContent.AppendLine($"{item.Id},{item.Amount},{item.IdDonatedNavigation.Name},{item.IdDonatedNavigation.ParentTaz},{item.IdDonatedNavigation.IdStatusNavigation.StatusName},{item.IdDonatedNavigation.Needed},{item.IdDonatedNavigation.NumberBuilding},{item.IdNeighborhoodNavigation.Name}" +
                    $",{item.IdDonorNavigation.FirstName+ " "+item.IdDonorNavigation.LastName},{item.IdDonorNavigation.Email},{item.IdDonorNavigation.City},{item.IdDonorNavigation.Phone}"); // Add data rows               
            }
           
            var csvData = Encoding.GetEncoding("windows-1255").GetBytes(csvContent.ToString());
            var csvStream = new MemoryStream(csvData);

            return  csvStream;
        }

        public void Create(DonationDTO ObjToAdd)
        {
            throw new NotImplementedException();
        }

        Task IService<DonationDTO>.Create(DonationDTO ObjToAdd)
        {
            throw new NotImplementedException();
        }
    }
}

/*Id
{
    get; set;
? IsAnonymous
ng? Dedication
Amount {
        get;
        IdDonated {
            ge
        IdDonor {
                get;
*/