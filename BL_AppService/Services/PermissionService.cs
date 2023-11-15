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
            permissionRepository = permissionRepository;
            mapper = mapper;

        }

        public void Create(PermissionDTO permissionDTO)
        {
            permissionRepository.Create(mapper.Map<Permission>(permissionDTO));
            
        }

        public void Delete(int id)
        {
            permissionRepository.Delete(id);
        }

        public List<PermissionDTO> GetAll()
        {
            List<Permission> permissions = permissionRepository.GetAll();
            return mapper.Map<List<PermissionDTO>>(permissions);
           
        }

        public PermissionDTO GetByTaz(int id)
        {
            return mapper.Map<PermissionDTO>(permissionRepository.GetById(id));
        }

        public void Update(PermissionDTO permissionDTO)
        {
           
            permissionRepository.Update(mapper.Map<Permission>(permissionDTO));
        }
    }
}
