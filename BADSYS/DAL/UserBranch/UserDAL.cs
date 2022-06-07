﻿using System;
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
        public void AddUser(User user, string password)
        {
            string salt = HashSalt.CreateSalt(8);
            string hashedPassword = HashSalt.GenerateSHA256Hash(password, salt);
            string sql = "INSERT INTO sa_users (firstName, lastName, email, photoPath, password, salt) VALUES (@firstname, @lastname, @email, " +
                "@photopath, @password, @salt); ";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("firstname", user.FirstName),
                new KeyValuePair<string, dynamic>("lastname", user.LastName),
                new KeyValuePair<string, dynamic>("email", user.Email),
                new KeyValuePair<string, dynamic>("photopath", user.PhotoPath),
                new KeyValuePair<string, dynamic>("password", password),
                new KeyValuePair<string, dynamic>("salt", salt)
            };

            ExecuteInsert(sql, parameters);
        }

        public void UpdateUser(int userId, User newUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
        
        public User GetUser(int userId)
        {
            string query = "SELECT userId, firstName, lastName, email, photoPath FROM sa_users WHERE userId = @userid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("userid", userId)
            };

            DataSet data = ExecuteSql(query, parameters);

            if (data != null)
            {
                int id = Convert.ToInt16(data.Tables[0].Rows[0]["userId"]);
                string firstName = data.Tables[0].Rows[0]["firstName"].ToString();
                string lastName = data.Tables[0].Rows[0]["lastName"].ToString();
                string email = data.Tables[0].Rows[0]["email"].ToString();
                string photoPath = data.Tables[0].Rows[0]["photoPath"].ToString();

                User user = new User(id, firstName, lastName, email, photoPath);
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT userId, firstName, lastName, email, photoPath FROM sa_users";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<User> userDetails = new List<User>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int userId = Convert.ToInt16(data.Tables[0].Rows[row]["userId"]);

                string firstName = data.Tables[0].Rows[row]["firstName"].ToString();
                string lastName = data.Tables[0].Rows[row]["lastName"].ToString();
                string email = data.Tables[0].Rows[row]["email"].ToString();
                string photoPath = data.Tables[0].Rows[row]["photoPath"].ToString();


                userDetails.Add(new User(userId, firstName, lastName, email, photoPath));
            }

            return userDetails;
        }
    }
}
