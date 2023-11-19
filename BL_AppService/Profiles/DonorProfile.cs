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
    public class DonorProfile:Profile
    {
        public DonorProfile()
        {
            CreateMap<Donor, DonorDTO>().ReverseMap();
            CreateMap<Donor, DonorAllDTO>().ReverseMap();
        }
       
    }
}
