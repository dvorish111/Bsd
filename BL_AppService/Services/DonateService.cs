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
using OfficeOpenXml;

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

        public async Task Create(DonateAllDTO donateAllDTO)
        {
            Donate donate = mapper.Map<Donate>(donateAllDTO);
            await donateRepository.Create(donate);
            /*            donateRepository.Create(mapper.Map<Donate>(donateAllDTO));
            */
        }

        public async Task Delete(int id)
        {
          await  donateRepository.Delete(id);
        }

        public async Task <List<DonateDTO>> GetAll()
        {
            List<Donate> donates = await donateRepository.GetAll();
            return mapper.Map<List<DonateDTO>>(donates);


        }
        public async Task<List<DonateDTO>> GetAllByNumOfChildren(int to)
        {
            return   mapper.Map<List<DonateDTO>>(await donateRepository.GetAllByNumOfChildren(to));
        }
        public async Task<List<DonateDTO>> GetAllByStatus(int id)
        {
            return  mapper.Map<List<DonateDTO>>(await donateRepository.GetAllByStatus(id));
        }
        public async Task<List<DonateDTO>> GetAllByNeeded(double needed)
        {
            return  mapper.Map<List<DonateDTO>>(await donateRepository.GetAllByNeeded(needed));
        }
        // public List<Donate> GetAllByGoul()
        //{
        //    return _context.Donates.ToList();
        //}

        public async Task<DonateAllDTO> GetByTaz(string taz)
        {

            return  mapper.Map<DonateAllDTO>(await donateRepository.GetByTaz(taz));

        }

        public async Task Update(DonateAllDTO donateAllDTO)
        {
            if (donateAllDTO.Name != null)
            {
                await donateRepository.Update(mapper.Map<Donate>(donateAllDTO));

            }
            else
            {
                donateRepository.UpdateRaised(donateAllDTO.Id, donateAllDTO.Raised);
            }
        }

       

        public async Task<DonateDTO> GetById(int id)
        {
            return  mapper.Map<DonateDTO> (await donateRepository.GetById(id));
        }

        public async Task<int> GetNumChildren()
        {
            return await donateRepository.GetNumChildren();
        }

        public async Task<int> GetNumFamily()
        {
            return await donateRepository.GetNumFamily();
        }


        /*  public async Task CraeteDonatesByExcel(IFormFile file)
          {
              using (var reader = new StreamReader(file.OpenReadStream()*//*,Encoding.GetEncoding("ISO-8859-1")*//*))
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
                          ParentTaz = values[0],
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

               await   donateRepository.CraeteDonatesByExcel(donates);

              }
          }*/
        
        public async Task<List<int>> CraeteDonatesByExcel(IFormFile file)
            
        {    List<int> invalidDonates = new List<int>();

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // פתיחת חבילת אקסל על ידי קריאת קובץ האקסל שהועלה
            using (var package = new ExcelPackage(file.OpenReadStream()))
            {
                // קבלת הגיליון הראשון בחבילת האקסל
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // יצירת רשימה לאובייקטי DTO של העזרות ולאובייקטי העזרה
                List<DonateAllDTO> donatesToAdd = new List<DonateAllDTO>();
                List<Donate> donates = new List<Donate>();

                // לולאה שעוברת על כל השורות בגיליון (משורה 2 והלאה)
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    // יצירת מערך נתונים לפי מספר העמודות בגיליון (8 במקרה זה)
                    var values = new string[8];

                    // לולאה שעוברת על כל העמודות בשורה הנוכחית
                    for (int col = 1; col <= 8; col++)
                    {
                        // קריאת ערך התא בעמודה הנוכחית בשורה הנוכחית
                        values[col - 1] = worksheet.Cells[row, col].Value?.ToString();
                        if (col == 4)
                        {
                            switch (values[col - 1]) {
                                case "נשוי":
                                    values[col - 1] = "1";
                                         break;
                                case "גרוש":
                                    values[col - 1] = "2";
                                    break;
                                case "אלמן":
                                    values[col - 1] = "3";
                                    break;
                                default: values[col - 1] = "1";
                                        break; 
                            }
                        }

                        if (col == 8)
                        {
                            switch (values[col - 1])
                            {
                                case "רמות א":
                                    values[col - 1] = "1";
                                    break;
                                case "רמות ב":
                                    values[col - 1] = "2";
                                    break;
                                case "רמות ג":
                                    values[col - 1] = "3";
                                    break;
                                case "רמות ד":
                                    values[col - 1] = "4";
                                    break;
                                case "רמות פולין":
                                    values[col - 1] = "5";
                                    break;
                                case "רמות א החדשה":
                                    values[col - 1] = "6";
                                    break;
                                default:
                                    values[col - 1] = "1";
                                    break;
                            }
                        }
                    }

                    // יצירת אובייקט DTO של העזרה ומילויו בנתונים מהמערך
                    DonateAllDTO donate = new DonateAllDTO();

                    if (!int.TryParse(values[2], out int numChildren) ||
                        !int.TryParse(values[3], out int idStatus) ||
                        !int.TryParse(values[5], out int needed) ||
                        !int.TryParse(values[6], out int numberBuilding) ||
                        !int.TryParse(values[7], out int idNeighborhood))
                    {
                        // אם יש לפחות אחד מהפרמטרים שאינו תקין, עובר לשורה הבאה
                        continue;
                    }

                    // אם נכנסנו לכאן, כל הפרמטרים תקינים וניתן למלא את העזרה
                    donate.NumChildren = numChildren;
                    donate.IdStatus = idStatus;
                    donate.ParentTaz = values[0];
                    donate.Name = values[1];
                    donate.Street = values[4];
                    donate.Needed = needed;
                    donate.NumberBuilding = numberBuilding;
                    donate.IdNeighborhood = idNeighborhood;

                    donatesToAdd.Add(donate);
                }


                // לולאה שעוברת על כל העזרות ברשימה וממירה אותן לעזרות מסוג Donate
                foreach (var item in donatesToAdd)
                {
                    donates.Add(mapper.Map<Donate>(item));
                }

                // יצירת העזרות במסד הנתונים באמצעות ה־repository
                

                invalidDonates = await donateRepository.CraeteDonatesByExcel(donates);
            }
            return invalidDonates;
        }

        public async Task<Stream>  GetDonatesByExcel()
        {
            var data =await donateRepository.GetAll();  
            var csvContent = new StringBuilder();
            csvContent.AppendLine("ParentTaz, Name, NumChildren, Status, Street, Needed, NumberBuilding, Neighborhood");
            foreach (var item in data)
            {
                csvContent.AppendLine($"{item.ParentTaz},{item.Name},{item.NumChildren},{item.IdStatusNavigation.StatusName},{item.Street},{item.Needed},{item.NumberBuilding},{item.IdNeighborhoodNavigation.Name}"); // Add data rows               
            }
            var csvData = Encoding.UTF8.GetBytes(csvContent.ToString());
            var csvStream = new MemoryStream(csvData);

            return  csvStream;
        }                        
        
    public async Task DeleteAllEntities()
    {
          await  donateRepository.DeleteAllEntities();
    }

        public Task Create(DonateDTO ObjToAdd)
        {
            throw new NotImplementedException();
        }

        public Task Update(DonateDTO ObjToUpdate)
        {
            throw new NotImplementedException();
        }
    }      }                          
                                 
                                 
                                 