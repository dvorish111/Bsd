using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAL.Models;

namespace BL_AppService.Profiles
{
    public class PermissionProfile: Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, LogInDTO>().ReverseMap();
            CreateMap<Permission, SignUpDTO>().ReverseMap();
        }
    }
}
