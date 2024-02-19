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
        Task Create(SignUpDTO donate);
        Task <SignUpDTO> GetByPassword_Email(string password, string email);
        Task UpdateByGmail(SignUpDTO signUpDTO, string gmail);

        Task<bool> ConfirmPassword (string password);
    }
}
