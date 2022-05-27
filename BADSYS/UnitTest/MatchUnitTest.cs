using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLL;
using DAL.MatchBranch;
using Models;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class MatchUnitTest
    {
        [TestMethod]
        public void AddMatch_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());

            // act
            mm.AddMatch(new Match(1, 1, "test1", "test2", 19, 22, MatchStatus.FINISHED, "semifinal"));
            Match expected = mm.GetMatchById(1);

            // assert
            Assert.AreEqual(expected.Id, 1);
            Assert.AreEqual(expected.TournamentId, 1);
            Assert.AreEqual(expected.PlayerOne, "test1");
            Assert.AreEqual(expected.PlayerTwo, "test2");
            Assert.AreEqual(expected.PlayerOneScore, 19);
            Assert.AreEqual(expected.PlayerTwoScore, 22);
            Assert.AreEqual(expected.Status, MatchStatus.FINISHED);
            Assert.AreEqual(expected.Stage, "semifinal");
        }

        [TestMethod]
        public void UpdateMatch_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());

            // act
            mm.UpdateMatch(0, new Match(1, 1, "test1", "test2", 19, 22, MatchStatus.FINISHED, "semifinal"));
            Match expected = mm.GetMatchById(0);

            // assert
            Assert.AreEqual(expected.Id, 1);
            Assert.AreEqual(expected.TournamentId, 1);
            Assert.AreEqual(expected.PlayerOne, "test1");
            Assert.AreEqual(expected.PlayerTwo, "test2");
            Assert.AreEqual(expected.PlayerOneScore, 19);
            Assert.AreEqual(expected.PlayerTwoScore, 22);
            Assert.AreEqual(expected.Status, MatchStatus.FINISHED);
            Assert.AreEqual(expected.Stage, "semifinal");
        }

        [TestMethod]
        public void GetMatchById_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());

            // act
            Match expected = mm.GetMatchById(0);

            // assert
            Assert.AreEqual(expected.Id, 0);
            Assert.AreEqual(expected.TournamentId, 0);
            Assert.AreEqual(expected.PlayerOne, "1");
            Assert.AreEqual(expected.PlayerTwo, "2");
            Assert.AreEqual(expected.PlayerOneScore, 22);
            Assert.AreEqual(expected.PlayerTwoScore, 19);
            Assert.AreEqual(expected.Status, MatchStatus.FINISHED);
            Assert.AreEqual(expected.Stage, "final");
        }

        [TestMethod]
        public void GetAllMatches_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());

            // act
            List<Match> expected = mm.GetAllMatches();

            // assert
            Assert.AreEqual(expected[0].Id, 0);
            Assert.AreEqual(expected[0].TournamentId, 0);
            Assert.AreEqual(expected[0].PlayerOne, "1");
            Assert.AreEqual(expected[0].PlayerTwo, "2");
            Assert.AreEqual(expected[0].PlayerOneScore, 22);
            Assert.AreEqual(expected[0].PlayerTwoScore, 19);
            Assert.AreEqual(expected[0].Status, MatchStatus.FINISHED);
            Assert.AreEqual(expected[0].Stage, "final");
        }

        [TestMethod]
        public void GetAllMatchesByTournamentId_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());

            // act
            List<Match> expected = mm.GetAllMatchesByTournamentId(0);

            // assert
            Assert.AreEqual(expected[0].Id, 0);
            Assert.AreEqual(expected[0].TournamentId, 0);
            Assert.AreEqual(expected[0].PlayerOne, "1");
            Assert.AreEqual(expected[0].PlayerTwo, "2");
            Assert.AreEqual(expected[0].PlayerOneScore, 22);
            Assert.AreEqual(expected[0].PlayerTwoScore, 19);
            Assert.AreEqual(expected[0].Status, MatchStatus.FINISHED);
            Assert.AreEqual(expected[0].Stage, "final");
        }
    }
}
