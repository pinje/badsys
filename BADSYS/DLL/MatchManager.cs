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

        public void GenerateRoundRobin(int tournamentId)
        {
            // get participants
            ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());
            List<Participation> list = participationManager.GetAllParticipationByTournament(tournamentId);

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

        public void GenerateSingleElimination(int tournamentId)
        {
            // get participants
            ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());
            List<Participation> list = participationManager.GetAllParticipationByTournament(tournamentId);

            // convert participants to string 
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
            int numberOfRounds = Convert.ToInt16(Math.Log(numberOfParticipants) / Math.Log(2));

            int bracketNumber = numberOfParticipants / 2;

            // generate matches
            if (numberOfParticipants == 2) // special case for 2 participants
            {
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[0]), Convert.ToInt16(teamsList[1]), 0, 0, 0, "Final"));
            } else if (numberOfParticipants == 4) // special case for 4 participants
            {
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[0]), Convert.ToInt16(teamsList[1]), 0, 0, 0, "Semifinals"));
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[2]), Convert.ToInt16(teamsList[3]), 0, 0, 0, "Semifinals"));
                AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Final"));
            } else if (numberOfParticipants == 8) // special case for 8 participants
            {
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[0]), Convert.ToInt16(teamsList[1]), 0, 0, 0, "Quarterfinals"));
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[2]), Convert.ToInt16(teamsList[3]), 0, 0, 0, "Quarterfinals"));
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[4]), Convert.ToInt16(teamsList[5]), 0, 0, 0, "Quarterfinals"));
                AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[6]), Convert.ToInt16(teamsList[7]), 0, 0, 0, "Quarterfinals"));
                AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Semifinals"));
                AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Semifinals"));
                AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Final"));
            } else
            {
                for (int round = 1; round < numberOfRounds+1; round++)
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
                        AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Quarterfinals"));
                        AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Quarterfinals"));
                        AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Quarterfinals"));
                        AddMatch(new Match(tournamentId, Convert.ToInt16(null), Convert.ToInt16(null), 0, 0, 0, "Quarterfinals"));
                    }
                    else
                    {
                        for (int participantId = 0; participantId < numberOfParticipants; participantId++)
                        {
                            AddMatch(new Match(tournamentId, Convert.ToInt16(teamsList[participantId]), Convert.ToInt16(teamsList[participantId+1]), 0, 0, 0, "Round of " + bracketNumber));
                            participantId++;
                        }
                    }
                }
            }
        }
    }
}
