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
        List<T> GetAll();
        T GetById(int id);
        void Create(T ObjToAdd);
        void Update(T ObjToUpdate);
        void Delete(int id);
    }
}
