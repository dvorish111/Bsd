using DAL.IRepositorys;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Permission>> GetAll()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<Permission> GetById(int permissionId)
        {
            return await _context.Permissions.FirstOrDefaultAsync(c => c.Id == permissionId);
        }

        public async Task Create(Permission permission)
        {
            await _context.Permissions.AddAsync(permission);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Permission permission)
        {
            var existingPermission = await _context.Permissions.FirstOrDefaultAsync(c => c.Password == permission.Password);
            if (existingPermission != null)
            {
                existingPermission.Password = permission.Password;
                existingPermission.Email = permission.Email;
                // existingPermission.Donates = Permission.Donates;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int permissionId)
        {
            var permission = await _context.Permissions.FirstOrDefaultAsync(c => c.Id == permissionId);
            if (permission != null)
            {
                _context.Permissions.Remove(permission);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Permission> GetByPassword_Email(string password, string email)
        {
            return await _context.Permissions.FirstOrDefaultAsync(c => c.Password == password && c.Email==email);
        }

        public async Task DeleteAllEntities()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateByGmail(Permission signUp, string gmail)
        {
            var existingPermission =  _context.Permissions.FirstOrDefault(c => c.Email == gmail);
            if (existingPermission != null)
            {
                existingPermission.ManagerName = signUp.ManagerName;
                existingPermission.Password = signUp.Password;
                existingPermission.Email = signUp.Email;
                // existingPermission.Donates = Permission.Donates;
               await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ConfirmPassword(string password)
        {
            var confirmPassword =await _context.Permissions.FirstOrDefaultAsync(c => c.Password == password);
            if(confirmPassword != null)
            {
                return true;
            }
            return false;
        }
    }
}
