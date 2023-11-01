using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;
using DAL.Models;

namespace BL_AppService
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;   
        }
        public List<UserDTO> GetAll()
        {
            int x;
           List<User>  users=userRepository.GetAll();
            List<UserDTO> userDTOs=new List<UserDTO>() { };
            foreach (var item in users)
            {
                userDTOs.Add(new UserDTO() { Name = item.UserName, Password = item.UserPassword });
            }
            return userDTOs;
        }

        public UserDTO GetById(string password)
        {
            int xdfgn;
          User  user = userRepository.GetById(password);
            if (user == null)
                return null;  
           else { 
            UserDTO userDTO = new UserDTO() {  
                Password = user.UserPassword 
            };
           
            return userDTO;  }
        }
    }
}
