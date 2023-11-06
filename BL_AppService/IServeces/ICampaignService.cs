using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BL_AppService.IServeces
{
    public interface ICampaignService
    {
        // Create a new campaign
        void CreateCampaign(CampaignDTO campaign);

        // Read campaign by ID
        CampaignDTO GetCampaignById(int id);

        // Update an existing campaign
        void UpdateCampaign(CampaignDTO campaign);

        // Delete a campaign by ID
        void DeleteCampaign(int id);
    }
}
