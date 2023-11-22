using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL.Models;
namespace BL_AppService.IServeces
{
    public interface IPermissionService: IService<LogInDTO>
    {
        public void Create(SignUpDTO donate);
        public LogInDTO GetByPassword_Email(string password, string email);
    }
}
