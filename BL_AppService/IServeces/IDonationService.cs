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
        Task <int> GetSumDonation();
        Task <int> GetSumDonationsByDonated(int IdDonated);
        Task <List<int>> GetAllSumDonationsByDonated();
        Task <Stream> GetDonationsByExcel();
        Task <List<DonationDTO>> GetAllDonationsByDonated(int IdDonated);        
        Task  Create(DonationAllDTO donationDTO);

    }
}
