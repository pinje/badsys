using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLL;
using DAL.TournamentBranch;
using Models;
using System.Collections.Generic;
using System;

namespace UnitTest
{
    [TestClass]
    public class TournamentUnitTest
    {
        [TestMethod]
        public void AddTournament_Validate()
        {
            // arrange 
            TournamentManager tm = new TournamentManager(new MockTournamentDAL());

            // act
            tm.AddTournament(new Tournament(1, "this is a test tournament", Convert.ToDateTime("05/05/2022"),
                Convert.ToDateTime("05/05/2022"), 2, 4, "test address", TournamentSystem.SINGLE_ELIMINATION, TournamentStatus.FINISHED));
            Tournament expected = tm.GetTournamentById(1);

            // assert
            Assert.AreEqual(expected.Description, "this is a test tournament");
            Assert.AreEqual(expected.StartDate, Convert.ToDateTime("05/05/2022"));
            Assert.AreEqual(expected.EndDate, Convert.ToDateTime("05/05/2022"));
            Assert.AreEqual(expected.MinPlayer, 2);
            Assert.AreEqual(expected.MaxPlayer, 4);
            Assert.AreEqual(expected.Address, "test address");
            Assert.AreEqual(expected.System, TournamentSystem.SINGLE_ELIMINATION);
            Assert.AreEqual(expected.Status, TournamentStatus.FINISHED);
        }

        [TestMethod]
        public void UpdateTournament_Validate()
        {
            // arrange 
            TournamentManager tm = new TournamentManager(new MockTournamentDAL());

            // act
            tm.UpdateTournament(0, new Tournament(0, "this is a test tournament", Convert.ToDateTime("05/05/2022"),
                Convert.ToDateTime("05/05/2022"), 2, 4, "test address", TournamentSystem.SINGLE_ELIMINATION, TournamentStatus.FINISHED));
            Tournament expected = tm.GetTournamentById(0);

            // assert
            Assert.AreEqual(expected.Description, "this is a test tournament");
            Assert.AreEqual(expected.StartDate, Convert.ToDateTime("05/05/2022"));
            Assert.AreEqual(expected.EndDate, Convert.ToDateTime("05/05/2022"));
            Assert.AreEqual(expected.MinPlayer, 2);
            Assert.AreEqual(expected.MaxPlayer, 4);
            Assert.AreEqual(expected.Address, "test address");
            Assert.AreEqual(expected.System, TournamentSystem.SINGLE_ELIMINATION);
            Assert.AreEqual(expected.Status, TournamentStatus.FINISHED);
        }

        [TestMethod]
        public void DeleteTournament_Validate()
        {
            // arrange 
            TournamentManager tm = new TournamentManager(new MockTournamentDAL());

            // act
            tm.DeleteTournament(0);
            List<Tournament> list = tm.GetAllTournaments();
            int expected = list.Count;

            // assert
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void GetTournamentById_Validate()
        {
            // arrange 
            TournamentManager tm = new TournamentManager(new MockTournamentDAL());

            // act
            Tournament expected = tm.GetTournamentById(0);

            // assert
            Assert.AreEqual(expected.Description, "this is a tournament");
            Assert.AreEqual(expected.StartDate, Convert.ToDateTime("05/05/2022"));
            Assert.AreEqual(expected.EndDate, Convert.ToDateTime("05/05/2022"));
            Assert.AreEqual(expected.MinPlayer, 4);
            Assert.AreEqual(expected.MaxPlayer, 12);
            Assert.AreEqual(expected.Address, "address");
            Assert.AreEqual(expected.System, TournamentSystem.ROUND_ROBIN);
            Assert.AreEqual(expected.Status, TournamentStatus.UPCOMING);
        }

        [TestMethod]
        public void GetAllTournaments_Validate()
        {
            // arrange 
            TournamentManager tm = new TournamentManager(new MockTournamentDAL());

            // act
            List<Tournament> expected = tm.GetAllTournaments();

            // assert
            Assert.AreEqual(expected[0].Id, 0);
            Assert.AreEqual(expected[0].Description, "this is a tournament");
            Assert.AreEqual(expected[0].StartDate, Convert.ToDateTime("05/05/2022"));
            Assert.AreEqual(expected[0].EndDate, Convert.ToDateTime("05/05/2022"));
            Assert.AreEqual(expected[0].MinPlayer, 4);
            Assert.AreEqual(expected[0].MaxPlayer, 12);
            Assert.AreEqual(expected[0].Address, "address");
            Assert.AreEqual(expected[0].System, TournamentSystem.ROUND_ROBIN);
            Assert.AreEqual(expected[0].Status, TournamentStatus.UPCOMING);
        }
    }
}
