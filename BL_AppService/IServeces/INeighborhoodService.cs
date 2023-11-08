using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BL_AppService.IServeces
{
    public interface INeighborhoodService
    {
        // Create a new campaign
        void CreateCampaign(NeighborhoodDTO campaign);

        // Read campaign by ID
        NeighborhoodDTO GetCampaignById(int id);

        // Update an existing campaign
        void UpdateCampaign(NeighborhoodDTO campaign);

        // Delete a campaign by ID
        void DeleteCampaign(int id);
    }
}
