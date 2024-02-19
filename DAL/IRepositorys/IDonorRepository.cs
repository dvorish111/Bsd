using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositorys
{
    public interface IDonorRepository:IRepository<Donor>
    {
        Task<List<Donor>> GetAllByCity(string city);
        Task<int> Create_ReturnID(Donor donor);
    }
}
