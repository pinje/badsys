using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLL;
using DAL.MatchBranch;
using DAL.ParticipationBranch;
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
            mm.AddMatch(new Match(1, 1, 3, 3, 19, 22, MatchStatus.FINISHED, "semifinal"));
            Match expected = mm.GetMatchById(1);

            // assert
            Assert.AreEqual(expected.Id, 1);
            Assert.AreEqual(expected.TournamentId, 1);
            Assert.AreEqual(expected.PlayerOne, 3);
            Assert.AreEqual(expected.PlayerTwo, 3);
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
            mm.UpdateMatch(0, new Match(1, 1, 3, 3, 19, 22, MatchStatus.FINISHED, "semifinal"));
            Match expected = mm.GetMatchById(0);

            // assert
            Assert.AreEqual(expected.Id, 1);
            Assert.AreEqual(expected.TournamentId, 1);
            Assert.AreEqual(expected.PlayerOne, 3);
            Assert.AreEqual(expected.PlayerTwo, 3);
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
            Assert.AreEqual(expected.PlayerOne, 1);
            Assert.AreEqual(expected.PlayerTwo, 2);
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
            Assert.AreEqual(expected[0].PlayerOne, 1);
            Assert.AreEqual(expected[0].PlayerTwo, 2);
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
            Assert.AreEqual(expected[0].PlayerOne, 1);
            Assert.AreEqual(expected[0].PlayerTwo, 2);
            Assert.AreEqual(expected[0].PlayerOneScore, 22);
            Assert.AreEqual(expected[0].PlayerTwoScore, 19);
            Assert.AreEqual(expected[0].Status, MatchStatus.FINISHED);
            Assert.AreEqual(expected[0].Stage, "final");
        }

        [TestMethod]
        public void GetAllMatchesByUserId_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());

            // act
            List<Match> expected = mm.GetAllMacthesByUserId(1);

            // assert
            Assert.AreEqual(expected[0].Id, 0);
            Assert.AreEqual(expected[0].TournamentId, 0);
            Assert.AreEqual(expected[0].PlayerOne, 1);
            Assert.AreEqual(expected[0].PlayerTwo, 2);
            Assert.AreEqual(expected[0].PlayerOneScore, 22);
            Assert.AreEqual(expected[0].PlayerTwoScore, 19);
            Assert.AreEqual(expected[0].Status, MatchStatus.FINISHED);
            Assert.AreEqual(expected[0].Stage, "final");
        }

        [TestMethod]
        public void GenerateRoundRobin_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());
            List<Participation> participants = pm.GetAllParticipationByTournament(0);
            // act
            mm.GenerateRoundRobin(0, participants);
            List<Match> matches = mm.GetAllMatches();

            // assert
            Assert.AreEqual(matches[1].Stage, "Round 1");
        }

        [TestMethod]
        public void GenerateSingleElimination_2Teams_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());
            List<Participation> participants = pm.GetAllParticipationByTournament(6);
            // act
            mm.GenerateSingleElimination(6, participants);
            List<Match> matches = mm.GetAllMatches();

            // assert
            Assert.AreEqual(matches[1].Stage, "Final");
            Assert.AreEqual(matches.Count - 1, 1); // remove initial match 
        }

        [TestMethod]
        public void GenerateSingleElimination_4Teams_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());
            List<Participation> participants = pm.GetAllParticipationByTournament(7);
            // act
            mm.GenerateSingleElimination(7, participants);
            List<Match> matches = mm.GetAllMatches();

            // assert
            Assert.AreEqual(matches[1].Stage, "Semifinals");
            Assert.AreEqual(matches[3].Stage, "Final");
            Assert.AreEqual(matches.Count - 1, 3); // remove initial match 
        }

        [TestMethod]
        public void GenerateSingleElimination_8Teams_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());
            List<Participation> participants = pm.GetAllParticipationByTournament(4);
            // act
            mm.GenerateSingleElimination(4, participants);
            List<Match> matches = mm.GetAllMatches();

            // assert
            Assert.AreEqual(matches[1].Stage, "Quarterfinals");
            Assert.AreEqual(matches[5].Stage, "Semifinals");
            Assert.AreEqual(matches[7].Stage, "Final");
            Assert.AreEqual(matches.Count - 1, 7); // remove initial match 
        }

        [TestMethod]
        public void GenerateSingleElimination_16Teams_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());
            List<Participation> participants = pm.GetAllParticipationByTournament(5);
            // act
            mm.GenerateSingleElimination(5, participants);
            List<Match> matches = mm.GetAllMatches();

            // assert
            Assert.AreEqual(matches[1].Stage, "Round of 8");
            Assert.AreEqual(matches.Count - 1, 15); // remove initial match 
        }

        [TestMethod]
        public void GenerateDoubleElimination_Validate()
        {
            // arrange 
            MatchManager mm = new MatchManager(new MockMatchDAL());
            ParticipationManager pm = new ParticipationManager(new MockParticipationDAL());
            List<Participation> participants = pm.GetAllParticipationByTournament(7);
            // act
            mm.GenerateDoubleElimination(7, participants);
            List<Match> matches = mm.GetAllMatches();

            // assert
            Assert.AreEqual(matches[1].Stage, "Semifinals");
            Assert.AreEqual(matches[5].Stage, "Lower Bracket Round X Bracket X");
            Assert.AreEqual(matches[6].Stage, "GRAND FINAL");
            Assert.AreEqual(matches.Count - 1, 6); // remove initial match 
        }




    }
}
