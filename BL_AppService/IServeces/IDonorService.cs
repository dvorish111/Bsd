using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL.Models;
namespace BL_AppService.IServeces
{
    public interface IDonorService: IService<DonorDTO>
    {
        Task<int> Create(DonorAllDTO donate);
        // public void Update(DonorAllDTO donate);//לא צריך עדכון לתורם
        Task<List<DonorDTO>> GetAllByCity(string city);
      
    }
}
