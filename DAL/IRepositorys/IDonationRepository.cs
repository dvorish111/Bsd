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
        
        public int GetSumDonation();

        public int GetSumDonationsByDonated(int IdDonated);
        public List<int> GetAllSumDonationsByDonated();

        public List<Donation> GetAllFullDetails();

        public List<Donation> GetAllDonationsByDonated(int IdDonated);

    }
}
