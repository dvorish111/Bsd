using DAL.IRepositorys;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace DAL.Repository
{
    public class PermissionRepository: IPermissionRepository
    {
         CampainContext _context;

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
            var existingPermission = _context.Permissions.FirstOrDefault(c => c.Password == permission.Password);
            if (existingPermission != null)
            {
                existingPermission.Password = permission.Password;
                existingPermission.Email = permission.Email;
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

        public Permission GetByPassword_Email(string password, string email)
        {
            return _context.Permissions.FirstOrDefault(c => c.Password == password && c.Email==email);
        }

        public void DeleteAllEntities()
        {
            throw new NotImplementedException();
        }

        public void UpdateByGmail(Permission signUp, string gmail)
        {
            var existingPermission = _context.Permissions.FirstOrDefault(c => c.Password == gmail);
            if (existingPermission != null)
            {
                existingPermission.ManagerName = signUp.ManagerName;
                existingPermission.Password = signUp.Password;
                existingPermission.Email = signUp.Email;
                // existingPermission.Donates = Permission.Donates;
                _context.SaveChanges();
            }
        }
    }
}
