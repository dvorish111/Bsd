using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BL_AppService.IServeces
{
    public interface IDonationService
    {
        // Create a new donationn
        void CreateDonation(DonationDTO donationn);

        // Read donationn by ID
        DonationDTO GetDonationById(int id);

        // Update an existing donationn
        void UpdateDonation(DonationDTO donationn);

        // Delete a donationn by ID
        void DeleteDonation(int id);
    }
}
