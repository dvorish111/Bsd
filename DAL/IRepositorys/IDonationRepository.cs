using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositorys
{
    public interface IDonationRepository: IRepository<Donation>
    {
        
       Task<int> GetSumDonation();
       
       Task<int> GetSumDonationsByDonated(int IdDonated);
       Task<List<int>> GetAllSumDonationsByDonated();
       
       Task<List<Donation>> GetAllFullDetails();
       
       Task<List<Donation>> GetAllDonationsByDonated(int IdDonated);

    }
}
