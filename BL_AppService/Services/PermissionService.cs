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

        public void Create(LogInDTO logInDTO)
        {
            permissionRepository.Create(mapper.Map<Permission>(logInDTO));
            
        }

        public void Create(SignUpDTO signUpDTO)
        {
            permissionRepository.Create(mapper.Map<Permission>(signUpDTO));
        }

        public void Delete(int id)
        {
            permissionRepository.Delete(id);
        }

        public void DeleteAllEntities()
        {
            throw new NotImplementedException();
        }

        public List<LogInDTO> GetAll()
        {
            List<Permission> permissions = permissionRepository.GetAll();
            return mapper.Map<List<LogInDTO>>(permissions);
           
        }

        public LogInDTO GetById(int id)
        {
            return mapper.Map<LogInDTO>(permissionRepository.GetById(id));
        }

        public SignUpDTO GetByPassword_Email(string password, string email)
        {
            return mapper.Map<SignUpDTO>(permissionRepository.GetByPassword_Email(password,email));
        }
        public void Update(LogInDTO logInDTO)
        {
           
            permissionRepository.Update(mapper.Map<Permission>(logInDTO));
        }

        public void UpdateByGmail(SignUpDTO signUpDTO, string gmail)
        {
            permissionRepository.UpdateByGmail(mapper.Map<Permission>(signUpDTO),gmail);
        }
    }
}
