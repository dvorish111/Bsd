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
        // Create a new donor
        void CreateDonor(DonorDTO donor);

        // Read donor by ID
        DonorDTO GetDonorById(int id);

        // Update an existing donor
        void UpdateDonor(DonorDTO donor);

        // Delete a donor by ID
        void DeleteDonor(int id);
    }
}
