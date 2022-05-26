using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.UserBranch
{
    public interface IUserDA
    {
        void AddUser(User user);
        void UpdateUser(User oldUser, User newUser);
        void DeleteUser(User user);
        User GetUser(int index);
        List<User> GetAllUsers();
    }
}
