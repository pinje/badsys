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
            um.AddUser(new User(1, "admin", "admin", "admin@gmail.com", "default.jpg"), "password");
            User expected = um.GetUser(1);

            // assert
            Assert.AreEqual(expected.Id, 1);
            Assert.AreEqual(expected.FirstName, "admin");
            Assert.AreEqual(expected.LastName, "admin");
            Assert.AreEqual(expected.Email, "admin@gmail.com");
            Assert.AreEqual(expected.PhotoPath, "default.jpg");
        }

        [TestMethod]
        public void UpdateUser_Validate()
        {
            // arrange 
            UserManager um = new UserManager(new MockUserDAL());

            // act
            um.UpdateUser(0, new User("test", "hagiwara", "shuhei@gmail.com", "test.jpg"));
            User expected = um.GetUser(0);

            // assert
            Assert.AreEqual(expected.FirstName, "test");
            Assert.AreEqual(expected.LastName, "hagiwara");
            Assert.AreEqual(expected.Email, "shuhei@gmail.com");
            Assert.AreEqual(expected.PhotoPath, "test.jpg");
        }

        [TestMethod]
        public void DeleteUser_Validate()
        {
            // arrange 
            UserManager um = new UserManager(new MockUserDAL());

            // act
            um.DeleteUser(0);
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
