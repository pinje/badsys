using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.MatchBranch;
using Models;
using DAL.ParticipationBranch;

namespace DLL
{
    public class MatchManager
    {
        IMatchDA match;
        public MatchManager(IMatchDA match)
        {
            this.match = match;
        }

        public void AddMatch(Match match)
        {
            this.match.AddMatch(match);
        }

        public void UpdateMatch(int matchId, Match match)
        {
            this.match.UpdateMatch(matchId, match);
        }

        public Match GetMatchById(int matchId)
        {
            return this.match.GetMatchById(matchId);
        }

        public List<Match> GetAllMatches()
        {
            return this.match.GetAllMatches();
        }

        public List<Match> GetAllMatchesByTournamentId(int tournamentId)
        {
            return this.match.GetAllMatchesByTournamentId(tournamentId);
        }

        public List<Match> GetAllMacthesByUserId(int userId)
        {
            return this.match.GetAllMatchesByUserId(userId);
        }

        public void GenerateRoundRobin(int tournamentId, List<Participation> participants)
        {
            // get participants
            List<Participation> list = participants;

            // convert participants id to string
            List<string> teamsList = new List<string>();
            foreach (Participation participation in list)
            {
                teamsList.Add(participation.PlayerId.ToString());
            }

            // add a "bye" team if even number of teams
            if (teamsList.Count % 2 != 0)
            {
                teamsList.Add("0");
            }

            // get number of participants
            int numberOfParticipants = teamsList.Count;

            // get number of days / rounds
            int numberOfRounds = (numberOfParticipants - 1);
            int halfSize = numberOfParticipants / 2;

            List<string> teams = new List<string>();

            teams.AddRange(teamsList); // Copy all the elements.
            teams.RemoveAt(0); // To exclude the first team.

            int teamsSize = teams.Count;

            for (int round = 0; round < numberOfRounds; round++)
            {
                int teamIdx = round % teamsSize;
                AddMatch(new Match(tournamentId, Convert.ToInt16(teams[teamIdx]), Convert.ToInt16(teamsList[0]), 0, 0, 0, "Round " + (round + 1)));

                for (int idx = 1; idx < halfSize; idx++)
                {
                    int firstTeam = (round + idx) % teamsSize;
                    int secondTeam = (round + teamsSize - idx) % teamsSize;
                    AddMatch(new Match(tournamentId, Convert.ToInt16(teams[firstTeam]), Convert.ToInt16(teams[secondTeam]), 0, 0, 0, "Round " + (round + 1)));
                }
            }
        }

        public void GenerateSingleElimination(int tournamentId, List<Participation> participants)
        {
            // get participants
            List<Participation> list = participants;

            // convert participants to string 

            List<string> teamsList = new List<string>();
            foreach (Participation participation in list)
            {
                teamsList.Add(participation.PlayerId.ToString());
            }

            // get number of participants
            int numberOfParticipants = teamsList.Count;

            // get number of days / rounds
            int numberOfRounds = Convert.ToInt16(Math.Log(numberOfParticipants) / Math.Log(2));

            int bracketNumber = numberOfParticipants / 2;

            // generate matches
            if (numberOfParticipants == 2) // special case for 2 participants
            {
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[0]), Convert.ToInt16(teamsList[1]), 0, 0, 0, "Final"));
            } else if (numberOfParticipants == 4) // special case for 4 participants
            {
                GenerateSingleEliminationForFour(tournamentId, teamsList);
            } else if (numberOfParticipants == 8) // special case for 8 participants
            {
                GenerateSingleEliminationForEight(tournamentId, teamsList);
            } else
            {
                GenerateSingleEliminationForAboveEight(tournamentId, teamsList, numberOfRounds, numberOfParticipants, bracketNumber);
            }
        }

        public void GenerateSingleEliminationForEight(int tournamentId, List<string> teamsList)
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[counter]), Convert.ToInt16(teamsList[counter+1]), 0, 0, 0, "Quarterfinals"));
                counter += 2;
            }
            AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Semifinals"));
            AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Semifinals"));
            AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Final"));
        }

        public void GenerateSingleEliminationForFour(int tournamentId, List<string> teamsList)
        {
            AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[0]), Convert.ToInt16(teamsList[1]), 0, 0, 0, "Semifinals"));
            AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[2]), Convert.ToInt16(teamsList[3]), 0, 0, 0, "Semifinals"));
            AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Final"));
        }

        public void GenerateEmptyQuaterFinalForEight(int tournamentId)
        {
            for (int i = 0; i < (8/2); i++)
            {
                AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Quarterfinals"));
            }
        }

        public void GenerateSingleEliminationForAboveEight(int tournamentId, List<string> teamsList, int numberOfRounds, int numberOfParticipants, int bracketNumber)
        {
            for (int round = 1; round < numberOfRounds + 1; round++)
            {
                if (round == numberOfRounds)
                {
                    // final
                    AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Final"));
                }
                else if (round == numberOfRounds - 1)
                {
                    // semi final
                    AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Semifinals"));
                    AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Semifinals"));
                }
                else if (round == numberOfRounds - 2)
                {
                    // quarter final
                    GenerateEmptyQuaterFinalForEight(tournamentId);
                }
                else
                {
                    for (int participantId = 0; participantId < numberOfParticipants; participantId++)
                    {
                        AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[participantId]), Convert.ToInt16(teamsList[participantId + 1]), 0, 0, 0, "Round of " + bracketNumber));
                        participantId++;
                    }
                }
            }
        }

        public void GenerateDoubleElimination(int tournamentId, List<Participation> participants)
        {
            // same as single elimination
            GenerateSingleElimination(tournamentId, participants);

            // get participants
            List<Participation> list = participants;

            // get number of participants
            int numberOfParticipants = list.Count;

            // get number of matches in lower bracket
            int totalNumberOfMatches = (numberOfParticipants * 2) - 2;
            int lowerBracketNumberOfMatches = totalNumberOfMatches - numberOfParticipants;

            for (int i = 0; i < lowerBracketNumberOfMatches; i++)
            {
                AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Lower Bracket Round X Bracket X"));
            }
            AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "GRAND FINAL"));
        }
    }
}
