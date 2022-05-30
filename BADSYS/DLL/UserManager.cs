using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UserBranch;
using Models;

namespace DLL
{
    public class UserManager
    {
        IUserDA user;

        public UserManager(IUserDA user)
        {
            this.user = user;
        }

        public void AddUser(User user)
        {
            this.user.AddUser(user);
        }

        public void UpdateUser(int userId, User newUser)
        {
            this.user.UpdateUser(userId, newUser);
        }

        public void DeleteUser(int userId)
        {
            this.user.DeleteUser(userId);
        }

        public User GetUser(int userId)
        {
            return this.user.GetUser(userId);
        }

        public List<User> GetAllUsers()
        {
            return this.user.GetAllUsers();
        }

    }

}
