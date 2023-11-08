using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BL_AppService.IServeces
{
    public interface IPermissionService
    {
        // Create a new campaign
        void CreateCampaign(StatusDTO campaign);

        // Read campaign by ID
        StatusDTO GetCampaignById(int id);

        // Update an existing campaign
        void UpdateCampaign(StatusDTO campaign);

        // Delete a campaign by ID
        void DeleteCampaign(int id);
    }
}
