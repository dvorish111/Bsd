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
    public class DonateProfile: Profile
    {
        public DonateProfile()
        {
            
           CreateMap<Donate, DonateDTO>().ReverseMap();
            CreateMap<Donate, DonateAllDTO>().ReverseMap();
        }


    }
}
