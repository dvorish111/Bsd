using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BL_AppService.IServeces
{
    public interface IDonateService
    {
        // Create a new campaign
        void CreateCampaign(DonateDTO campaign);

        // Read campaign by ID
        DonateDTO GetCampaignById(int id);

        // Update an existing campaign
        void UpdateCampaign(DonateDTO campaign);

        // Delete a campaign by ID
        void DeleteCampaign(int id);
    }
}
