using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLL;
using DAL.ParticipationBranch;
using Models;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class ParticipationUnitTest
    {
        [TestMethod]
        public void AddParticipation_Validate()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            pm.AddParticipation(new Participation(1, 2));
            List<Participation> list = pm.GetAllParticipation();
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 6);
        }

        [TestMethod]
        public void DeleteParticipation_Validate()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            pm.DeleteParticipation(new Participation(1, 2));
            List<Participation> list = pm.GetAllParticipation();
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 4);
        }

        [TestMethod]
        public void GetAllParticipation_Validate()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            List<Participation> list = pm.GetAllParticipation();
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 5);
        }

        [TestMethod]
        public void GetAllParticipationByTournament_Validate_None()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            List<Participation> list = pm.GetAllParticipationByTournament(4);
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void GetAllParticipationByTournament_Validate_One()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            List<Participation> list = pm.GetAllParticipationByTournament(3);
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 1);
        }

        [TestMethod]
        public void GetAllParticipationByTournament_Validate_Two()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            List<Participation> list = pm.GetAllParticipationByTournament(2);
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 2);
        }

        [TestMethod]
        public void GetAllParticipationByPlayer_Validate_None()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            List<Participation> list = pm.GetAllParticipationByPlayer(3);
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void GetAllParticipationByPlayer_Validate_One()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            List<Participation> list = pm.GetAllParticipationByPlayer(1);
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 2);
        }

        [TestMethod]
        public void GetAllParticipationByPlayer_Validate_Two()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            List<Participation> list = pm.GetAllParticipationByPlayer(2);
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 3);
        }

        [TestMethod]
        public void GetParticipantsNameByTournament_Validate()
        {
            // arrange 
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());

            // act
            List<List<string>> list = pm.GetParticipantsNameByTournament(2);
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 2);
        }

    }
}