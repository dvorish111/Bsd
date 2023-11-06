using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BL_AppService.IServeces
{
    public interface IDonorService
    {
        // Create a new campaign
        void CreateCampaign(DonorDTO campaign);

        // Read campaign by ID
        DonorDTO GetCampaignById(int id);

        // Update an existing campaign
        void UpdateCampaign(DonorDTO campaign);

        // Delete a campaign by ID
        void DeleteCampaign(int id);
    }
}
