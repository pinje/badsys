using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.UserBranch
{
    public class MockUserDAL : IUserDA
    {
        List<User> users;

        public MockUserDAL()
        {
            users = new List<User>();
            users.Add(new User("shuhei", "hagiwara", "shuhei@gmail.com", ""));
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            int index = users.FindIndex(x => 
            x.FirstName == oldUser.FirstName &&
            x.LastName == oldUser.LastName &&
            x.Email == oldUser.Email);
            users[index] = newUser;
        }
        public void DeleteUser(User user)
        {
            users.RemoveAll(x => 
            x.FirstName == user.FirstName &&
            x.LastName == user.LastName &&
            x.Email == user.Email);
        }

        public User GetUser(int index)
        {
            return users[index];
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}
