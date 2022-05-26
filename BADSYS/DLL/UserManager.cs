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

        public void UpdateUser(User oldUser, User newUser)
        {
            this.user.UpdateUser(oldUser, newUser);
        }

        public void DeleteUser(User user)
        {
            this.user.DeleteUser(user);
        }

        public User GetUser(int index)
        {
            return this.user.GetUser(index);
        }

        public List<User> GetAllUsers()
        {
            return this.user.GetAllUsers();
        }

    }

}
