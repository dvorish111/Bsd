﻿using System;
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
    }
}
