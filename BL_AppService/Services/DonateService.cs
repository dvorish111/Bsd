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
using Microsoft.AspNetCore.Http;
using CsvHelper;
using System.IO;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

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
        public List<DonateDTO> GetAllByNumOfChildren(int to)
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

        public DonateAllDTO GetByTaz(int taz)
        {

            return mapper.Map<DonateAllDTO>(donateRepository.GetByTaz(taz));

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
            return mapper.Map<DonateDTO> (donateRepository.GetById(id));
        }

        public int GetNumChildren()
        {
            return donateRepository.GetNumChildren();
        }

        public int GetNumFamily()
        {
            return donateRepository.GetNumFamily();
        }
       

        public void CraeteDonatesByExcel(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()/*,Encoding.GetEncoding("ISO-8859-1")*/))
            {  
                  List<DonateAllDTO> donatesToAdd = new List<DonateAllDTO>();
                List<Donate> donates = new List<Donate>();
                if (!reader.EndOfStream)
                    {

                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0]!=  "ParentTaz" &&
                        values[1] != "Name" &&
                        values[2] != "NumChildren" && 
                        values[3] != "IdStatus"&&
                        values[4] != "Street" &&
                        values[5] != "Needed" &&
                        values[6] != "NumberBuilding" &&
                        values[7] != "IdNeighborhood")
                    {
                        return;
                    }
                    reader.ReadLine();
                    }

              

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                  


                    DonateAllDTO donate = new DonateAllDTO
                    {
                        ParentTaz = int.Parse(values[0]),
                        Name = values[1],
                        NumChildren = int.Parse(values[2]),
                        IdStatus = int.Parse(values[3]),
                        Street = values[4],
                        Needed = int.Parse(values[5]),
                        NumberBuilding = int.Parse(values[6]),
                        IdNeighborhood = int.Parse(values[7])
                    };
                    donatesToAdd.Add(donate);      

                }
                foreach (var item in donatesToAdd)
                {
                    donates.Add(mapper.Map<Donate>(item));
                }

                donateRepository.CraeteDonatesByExcel(donates);

            }
        }
        public Stream GetDonatesByExcel()
        {
            var data = donateRepository.GetAll();  
            var csvContent = new StringBuilder();
            csvContent.AppendLine("ParentTaz, Name, NumChildren, Status, Street, Needed, NumberBuilding, Neighborhood");
            foreach (var item in data)
            {
                csvContent.AppendLine($"{item.ParentTaz},{item.Name},{item.NumChildren},{item.IdStatusNavigation.StatusName},{item.Street},{item.Needed},{item.NumberBuilding},{item.IdNeighborhoodNavigation.Name}"); // Add data rows               
            }
            var csvData = Encoding.UTF8.GetBytes(csvContent.ToString());
            var csvStream = new MemoryStream(csvData);

            return csvStream;
        }                        
        
    public void DeleteAllEntities()
    {
            donateRepository.DeleteAllEntities();
    }

}      }                          
                                 
                                 
                                 