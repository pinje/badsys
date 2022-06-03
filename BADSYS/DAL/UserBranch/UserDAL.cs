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
        public void AddUser(User user)
        {
            throw new NotImplementedException();
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
            string query = "SELECT * FROM sa_users WHERE userId = @userid";

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
