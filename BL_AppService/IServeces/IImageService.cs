using Common;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_AppService.IServeces
{
    public interface IImageService:IService<ImagesDTO>
    {
        Task SaveImage(ImagesDTO imagesDTO);

    }
}
