using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL_AppService.IServeces;
using Common;
using DAL.IRepositorys;
using DAL.Models;
namespace BL_AppService.Services
{
    public class PermissionService : IPermissionService
    {
        IPermissionRepository permissionRepository;
        IMapper mapper;
        public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
        {
           this. permissionRepository = permissionRepository;
           this.mapper = mapper;

        }

        public async Task<bool> ConfirmPassword(string password)
        {
            bool result =await permissionRepository.ConfirmPassword(password);
            return result;
        }

        public async Task Create(LogInDTO logInDTO)
        {
           await permissionRepository.Create(mapper.Map<Permission>(logInDTO));
            
        }

        public async Task Create(SignUpDTO signUpDTO)
        {
           await permissionRepository.Create(mapper.Map<Permission>(signUpDTO));
        }

        public async Task Delete(int id)
        {
          await  permissionRepository.Delete(id);
        }

        public async Task DeleteAllEntities()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LogInDTO>> GetAll()
        {
            List<Permission> permissions =await permissionRepository.GetAll();
            return  mapper.Map<List<LogInDTO>>(permissions);
           
        }

        public async Task<LogInDTO> GetById(int id)
        {
            return  mapper.Map<LogInDTO>(await permissionRepository.GetById(id));
        }

        public async Task<SignUpDTO> GetByPassword_Email(string password, string email)
        {
            return  mapper.Map<SignUpDTO>(await permissionRepository.GetByPassword_Email(password,email));
        }
        public async Task Update(LogInDTO logInDTO)
        {
           
           await permissionRepository.Update(mapper.Map<Permission>(logInDTO));
        }

        public async Task UpdateByGmail(SignUpDTO signUpDTO, string gmail)
        {
           await permissionRepository.UpdateByGmail(mapper.Map<Permission>(signUpDTO),gmail);
        }
    }
}
