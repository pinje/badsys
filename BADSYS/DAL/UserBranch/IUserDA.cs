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
        User GetUser(int userId);
        int GetUserIdByEmail(string email);
        List<User> GetAllUsers();
        List<List<string>> GetAllUsersForAuthentication();
    }
}
