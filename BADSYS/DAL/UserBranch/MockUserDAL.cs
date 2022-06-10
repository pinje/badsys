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
        List<List<string>> login;

        public MockUserDAL()
        {
            users = new List<User>();
            users.Add(new User(12, "shuhei", "hagiwara", "shuhei@gmail.com", ""));

            login = new List<List<string>>();
            login.Add(new List<string> { "0", "ict@gmail.com", "SNHqq4pLu3sK585WLSCScNXqBkm07Hc3lPTAXwqlQjI=", "DubNxy9DddA=" });
        }

        public void AddUser(User user, string password)
        {
            users.Add(user);
        }

        public User GetUser(int userId)
        {
            return users[userId];
        }

        public int GetUserIdByEmail(string email)
        {
            int userId = 0;

            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    userId = user.Id;
                }
            }

            return userId;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public List<List<string>> GetAllUsersForAuthentication()
        {
            return login;
        }
    }
}
