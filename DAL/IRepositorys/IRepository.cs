using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositorys
{
    public interface IRepository<T>
    {
       Task< List<T>> GetAll();
        Task< T> GetById(int id);
        Task Create(T ObjToAdd);
        Task Update(T ObjToUpdate);
        Task Delete(int id);
        Task DeleteAllEntities();
    }
}
