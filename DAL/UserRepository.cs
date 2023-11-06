using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Models;

namespace DAL
{
    internal class UserRepository : IUserRepository
    {
        CampainContext CampainContext; 
        UserssContext context;
        public UserRepository(UserssContext context)
        {
            this.context = context;
        }
        public void Add(User ObjToAdd)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            Console.WriteLine(context.Users.Count());
            Console.WriteLine(CampainContext.ContextId.ToString());
            return context.Users.ToList();
        }

        public User GetById( string password)
        {
            var user = context.Users.FirstOrDefault(p => p.UserPassword == password );
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void Update(User ObjToUpdate)
        {
          
            throw new NotImplementedException();
        }
       
    }
}
