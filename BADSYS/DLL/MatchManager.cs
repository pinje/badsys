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

            // get number of participants
            ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());
            List<Participation> list = participationManager.GetAllParticipationByTournament(tournamentId);
            List<string> teamsList = new List<string>();

            foreach (Participation participation in list)
            {
                teamsList.Add(participation.PlayerId.ToString());
            }
            int numberOfParticipants = list.Count;


            if (teamsList.Count % 2 != 0)
            {
                teamsList.Add("0");
            }

            int numDays = (numberOfParticipants - 1);
            int halfSize = numberOfParticipants / 2;

            List<string> teams = new List<string>();

            teams.AddRange(teamsList); // Copy all the elements.
            teams.RemoveAt(0); // To exclude the first team.

            int teamsSize = teams.Count;

            for (int day = 0; day < numDays; day++)
            {
                int teamIdx = day % teamsSize;
                AddMatch(new Match(tournamentId, Convert.ToInt16(teams[teamIdx]), Convert.ToInt16(teamsList[0]), 0, 0, 0, "Round " + (day + 1)));

                for (int idx = 1; idx < halfSize; idx++)
                {
                    int firstTeam = (day + idx) % teamsSize;
                    int secondTeam = (day + teamsSize - idx) % teamsSize;
                    AddMatch(new Match(tournamentId, Convert.ToInt16(teams[firstTeam]), Convert.ToInt16(teams[secondTeam]), 0, 0, 0, "Round " + (day + 1)));
                }
            }
        }
    }
}
