using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_AppService.IServeces;
using Common;
using DAL.IRepositorys;

namespace BL_AppService.Services
{
    public class DonateService: IDonateService
    {
        private readonly IDonateRepository donateRepository;

        public DonateService(IDonateRepository repository)
        {
            donateRepository = repository;
        }

        public void CreateDonate(DonateDTO donate)
        {
            throw new NotImplementedException();
        }

        public void DeleteDonate(int id)
        {
            throw new NotImplementedException();
        }

        public DonateDTO GetCDonateById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDonaten(DonateDTO donate)
        {
            throw new NotImplementedException();
        }
    }
}
