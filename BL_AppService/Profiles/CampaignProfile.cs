using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using Common;

namespace BL_AppService.Profiles
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignDTO>().ReverseMap();
        }
      
    }
}


