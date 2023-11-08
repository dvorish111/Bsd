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
        // Create a new Permission
        void CreatePermission(StatusDTO Permission);

        // Read Permission by ID
        StatusDTO GetPermissionById(int id);

        // Update an existing Permission
        void UpdatePermission(StatusDTO Permission);

        // Delete a Permission by ID
        void DeletePermission(int id);
    }
}
