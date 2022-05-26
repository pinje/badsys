using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLL;
using DAL.UserBranch;
using Models;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void AddUser_Validate()
        {
            // arrange 
            UserManager um = new UserManager(new MockUserDAL());

            // act
            um.AddUser(new User("admin", "admin", "admin@gmail.com", ""));
            List<User> list = um.GetAllUsers();
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 2);
        }

        [TestMethod]
        public void UpdateUser_Validate()
        {
            // arrange 
            UserManager um = new UserManager(new MockUserDAL());

            // act
            um.UpdateUser(new User("shuhei", "hagiwara", "shuhei@gmail.com", ""), new User("test", "hagiwara", "shuhei@gmail.com", ""));
            User user = um.GetUser(0);
            string expected = user.FirstName;

            // assert
            Assert.AreEqual(expected, "test");
        }

        [TestMethod]
        public void DeleteUser_Validate()
        {
            // arrange 
            UserManager um = new UserManager(new MockUserDAL());

            // act
            um.DeleteUser(new User("shuhei", "hagiwara", "shuhei@gmail.com", ""));
            List<User> list = um.GetAllUsers();
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void GetAllUsers_Validate()
        {
            // arrange 
            UserManager um = new UserManager(new MockUserDAL());

            // act
            User user = um.GetUser(0);

            // assert
            Assert.AreEqual(user.FirstName, "shuhei");
            Assert.AreEqual(user.LastName, "hagiwara");
            Assert.AreEqual(user.Email, "shuhei@gmail.com");
            Assert.AreEqual(user.PhotoPath, "");
        }

        [TestMethod]
        public void GetUser_Validate()
        {
            // arrange 
            UserManager um = new UserManager(new MockUserDAL());

            // act
            List<User> list = um.GetAllUsers();
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 1);
        }
    }
}
