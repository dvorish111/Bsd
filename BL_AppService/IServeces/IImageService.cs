using Common;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_AppService.IServeces
{
    public interface IImageService:IService<ImagesDTO>
    {
        Task SaveImage(ImagesSaveDTO ImagesSaveDTO);
              
        
/*        Task SaveImage(IFormFile file,int num);
*/    }
}
