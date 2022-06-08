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
        void AddUser(User user, string password);
        void UpdateUser(int userId, User newUser);
        void DeleteUser(int userId);
        User GetUser(int userId);
        List<User> GetAllUsers();
        List<List<string>> GetAllUsersForAuthentication();
    }
}
