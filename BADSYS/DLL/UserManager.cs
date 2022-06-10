using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UserBranch;
using Models;
using DAL;

namespace DLL
{
    public class UserManager
    {
        IUserDA user;

        public UserManager(IUserDA user)
        {
            this.user = user;
        }

        public void AddUser(User user, string password)
        {
            this.user.AddUser(user, password);
        }

        public User GetUser(int userId)
        {
            return this.user.GetUser(userId);
        }

        public int GetUserIdByEmail(string email)
        {
            return this.user.GetUserIdByEmail(email);
        }

        public List<User> GetAllUsers()
        {
            return this.user.GetAllUsers();
        }

        public List<List<string>> GetAllUsersForAuthentication()
        {
            return this.user.GetAllUsersForAuthentication();
        }

        public bool Login(string email, string password)
        {
            List<List<string>> users = GetAllUsersForAuthentication();
            string hashedCheckPassword;
            foreach (List<string> user in users)
            {
                if (user[1] == email)
                {
                    hashedCheckPassword = HashSalt.GenerateSHA256Hash(password, user[3]);
                    if (hashedCheckPassword.Equals(user[2]))
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

    }

}
