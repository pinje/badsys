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

        [TestMethod]
        public void GetUserIdByEmail_Validate()
        {
            // arrange 
            UserManager um = new UserManager(new MockUserDAL());

            // act
            int expected = um.GetUserIdByEmail("shuhei@gmail.com");

            // assert
            Assert.AreEqual(expected, 12);
        }

        [TestMethod]
        public void Login_Valid_Validate()
        {
            // arrange
            UserManager um = new UserManager(new MockUserDAL());

            // act
            bool result = um.Login("ict@gmail.com", "Fontys123#");

            // assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Login_WrongEmail_Validate()
        {
            // arrange
            UserManager um = new UserManager(new MockUserDAL());

            // act
            bool result = um.Login("fontys@gmail.com", "Fontys123#");

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void Login_WrongPassword_Validate()
        {
            // arrange
            UserManager um = new UserManager(new MockUserDAL());

            // act
            bool result = um.Login("ict@gmail.com", "ICT123#");

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void Login_AllWrong_Validate()
        {
            // arrange
            UserManager um = new UserManager(new MockUserDAL());

            // act
            bool result = um.Login("fontys@gmail.com", "ICT123#");

            // assert
            Assert.AreEqual(result, false);
        }
    }
}
