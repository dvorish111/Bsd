using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;

using DAL.Models;
using Microsoft.AspNetCore.Http;

namespace BL_AppService.IServeces
{
    public interface IDonateService: IService<DonateDTO>
    {
         Task  Create(DonateAllDTO donate);
         Task Update(DonateAllDTO donate);
        Task<DonateAllDTO> GetByTaz(string donateTaz);
        Task<List<DonateDTO>> GetAllByNeeded(double id);
        Task<List<DonateDTO>> GetAllByStatus(int id);
        Task<List<DonateDTO>> GetAllByNumOfChildren( int to);
        Task<int> GetNumChildren();
        Task<int>  GetNumFamily();
        public Task<List<int>> CraeteDonatesByExcel(IFormFile file);
        public Task< Stream> GetDonatesByExcel();


    }
}
