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
    public class DonationProfile:Profile
    {
        public DonationProfile()
        {
            CreateMap<Donation, DonationDTO>().ReverseMap();
        }
    }
}
