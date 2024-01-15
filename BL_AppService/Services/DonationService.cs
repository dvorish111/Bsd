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
        //public List<DonationDTO> GetAllByDonated(int IdDonated)
        //{
        //    List<Donation> donations = donationRepository.GetAllByDonated();
        //    return mapper.Map<List<DonationDTO>>(donations);
        //}
        public DonationDTO GetById(int id)
        {
            return mapper.Map<DonationDTO>(donationRepository.GetById(id));

        }

        public int GetSumDonation()
        {
            return  donationRepository.GetSumDonation();

        }

        public int GetSumDonationsByDonated(int IdDonated)
        {
            return donationRepository.GetSumDonationsByDonated(IdDonated);
        }

        public List<int> GetAllSumDonationsByDonated()
        {
            return donationRepository.GetAllSumDonationsByDonated();
        }
        public void Update(DonationDTO donationDTO)
        {          
            donationRepository.Update(mapper.Map<Donation>(donationDTO));
        }
        public void DeleteAllEntities()
        {
            donationRepository.DeleteAllEntities();
        }


        public Stream GetDonationsByExcel()
        {
            var data = donationRepository.GetAllFullDetails();
            var csvContent = new StringBuilder();
            csvContent.AppendLine(" ID,Amount,Donated Name, Donated ParentTaz,Status,Needed,NumberBuilding,Neighborhood,Donor Name,Donor Email,Donor City,Donor Phone");
         //   csvContent.AppendLine("מספר תרומה, סכום תרומה, שם הנתרם, תז הנתרם, סטטוס הנתרם, כמה צריך, מספר בנין,שכונה,ןשם התורם , מייל התורם, עיר, טלפון התורם");
            foreach (var item in data)
            {
                csvContent.AppendLine($"{item.Id},{item.Amount},{item.IdDonatedNavigation.Name},{item.IdDonatedNavigation.ParentTaz},{item.IdDonatedNavigation.IdStatusNavigation.StatusName},{item.IdDonatedNavigation.Needed},{item.IdDonatedNavigation.NumberBuilding},{item.IdNeighborhoodsNavigation.Name}" +
                    $",{item.IdDonorNavigation.FirstName+ " "+item.IdDonorNavigation.LastName},{item.IdDonorNavigation.Email},{item.IdDonorNavigation.City},{item.IdDonorNavigation.Phone}"); // Add data rows               
            }
           
            var csvData = Encoding.GetEncoding("windows-1255").GetBytes(csvContent.ToString());
            var csvStream = new MemoryStream(csvData);

            return csvStream;
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