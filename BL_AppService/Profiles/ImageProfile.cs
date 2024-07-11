using AutoMapper;
using Common;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_AppService.Profiles
{
    public class ImageProfile:Profile
    {
        public ImageProfile()
        {
            CreateMap<Images, ImagesDTO>().ReverseMap();
            CreateMap<Images, ImagesSaveDTO>().ReverseMap();
        }

    }
}
