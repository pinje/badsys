using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DAL.UserBranch
{
    public class UserDAL : DAL, IUserDA
    {
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
        
        public User GetUser(int index)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
