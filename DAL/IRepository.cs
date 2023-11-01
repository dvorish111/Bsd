using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(string password);
        void Add(T ObjToAdd);
        void Update(T ObjToUpdate);
        void Delete(int id);
    }
}
