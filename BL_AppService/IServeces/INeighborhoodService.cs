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
        // Create a new Neighborhood
        void CreateNeighborhood(NeighborhoodDTO Neighborhood);

        // Read Neighborhood by ID
        NeighborhoodDTO GetNeighborhoodById(int id);

        // Update an existing Neighborhood
        void UpdateNeighborhood(NeighborhoodDTO Neighborhood);

        // Delete a Neighborhood by ID
        void DeleteNeighborhood(int id);
    }
}
