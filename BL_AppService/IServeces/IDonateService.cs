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
        public void Create(DonateAllDTO donate);
        public void Update(DonateAllDTO donate);
        public DonateDTO GetByTaz(int donateTaz);
        List<DonateDTO> GetAllByNeeded(double id);
        List<DonateDTO> GetAllByStatus(int id);
        List<DonateDTO> GetAllByNumOfChildren( int to);
        int GetNumChildren();
        int GetNumFamily();
        public void CraeteDonatesByExcel(IFormFile file);
        public Stream GetDonatesByExcel();


    }
}
