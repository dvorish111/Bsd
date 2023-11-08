using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class PermissionRepository
    {
        private readonly CampainContext _context;

        public PermissionRepository(CampainContext context)
        {
            _context = context;
        }

        public List<Permission> GetAllPermissions()
        {
            return _context.Permissions.ToList();
        }

        public Permission GetPermissionById(int permissionId)
        {
            return _context.Permissions.FirstOrDefault(c => c.Id == permissionId);
        }

        public void AddPermission(Permission permission)
        {
            _context.Permissions.Add(permission);
            _context.SaveChanges();
        }

        public void UpdatePermission(Permission permission)
        {
            var existingPermission = _context.Permissions.FirstOrDefault(c => c.Id == permission.Id);
            if (existingPermission != null)
            {
                existingPermission.Password = permission.Password;
                // existingPermission.Donates = Permission.Donates;
                _context.SaveChanges();
            }
        }

        public void DeletePermission(int permissionId)
        {
            var permission = _context.Permissions.FirstOrDefault(c => c.Id == permissionId);
            if (permission != null)
            {
                _context.Permissions.Remove(permission);
                _context.SaveChanges();
            }
        }
    }
}
