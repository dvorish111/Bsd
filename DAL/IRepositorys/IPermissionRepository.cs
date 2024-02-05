using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositorys
{
    public interface IPermissionRepository :IRepository<Permission>
    {
        Task<Permission> GetByPassword_Email(string password, string email);
        Task UpdateByGmail(Permission signUp, string gmail);


    }
}
