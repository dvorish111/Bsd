using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace BL_AppService.IServeces
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T ObjToAdd);
        Task Update(T ObjToUpdate);
        Task Delete(int id);

        Task DeleteAllEntities();
    }
}
