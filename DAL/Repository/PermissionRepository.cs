using DAL.IRepositorys;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace DAL.Repository
{
    public class PermissionRepository: IPermissionRepository
    {
        private readonly CampainContext _context;

        public PermissionRepository(CampainContext context)
        {
            _context = context;
        }

        public List<Permission> GetAll()
        {
            return _context.Permissions.ToList();
        }

        public Permission GetById(int permissionId)
        {
            return _context.Permissions.FirstOrDefault(c => c.Id == permissionId);
        }

        public void Create(Permission permission)
        {
            _context.Permissions.Add(permission);
            _context.SaveChanges();
        }

        public void Update(Permission permission)
        {
            var existingPermission = _context.Permissions.FirstOrDefault(c => c.Id == permission.Id);
            if (existingPermission != null)
            {
                existingPermission.Password = permission.Password;
                // existingPermission.Donates = Permission.Donates;
                _context.SaveChanges();
            }
        }

        public void Delete(int permissionId)
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
