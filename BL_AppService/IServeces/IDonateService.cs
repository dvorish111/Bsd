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
        // Create a new donate
        void CreateDonate(DonateDTO donate);

        // Read donate by ID
        DonateDTO GetCDonateById(int id);

        // Update an existing donate
        void UpdateDonaten(DonateDTO donate);

        // Delete a donate by ID
        void DeleteDonate(int id);
    }
}
