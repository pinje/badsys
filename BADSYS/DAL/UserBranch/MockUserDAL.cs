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
            users.Add(new User(0, "shuhei", "hagiwara", "shuhei@gmail.com", ""));
        }

        public void AddUser(User user, string password)
        {
            users.Add(user);
        }

        public void UpdateUser(int userId, User newUser)
        {
            users[userId] = newUser;
        }

        public void DeleteUser(int userId)
        {
            users.RemoveAt(userId);
        }

        public User GetUser(int userId)
        {
            return users[userId];
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}
