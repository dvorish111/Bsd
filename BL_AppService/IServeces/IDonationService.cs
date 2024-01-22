using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL.Models;
namespace BL_AppService.IServeces
{
    public interface IDonationService: IService<DonationDTO>
    {
      public int GetSumDonation();
      public int GetSumDonationsByDonated(int IdDonated);
        public List<int> GetAllSumDonationsByDonated();
        public Stream GetDonationsByExcel();
        public List<DonationDTO> GetAllDonationsByDonated(int IdDonated);

        public void Create(DonationAllDTO donationDTO);

    }
}
