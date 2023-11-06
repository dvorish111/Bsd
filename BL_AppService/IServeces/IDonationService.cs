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
        // Create a new campaign
        void CreateCampaign(DonationDTO campaign);

        // Read campaign by ID
        DonationDTO GetCampaignById(int id);

        // Update an existing campaign
        void UpdateCampaign(DonationDTO campaign);

        // Delete a campaign by ID
        void DeleteCampaign(int id);
    }
}
