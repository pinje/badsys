using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.ParticipationBranch;

namespace DAL.MatchBranch
{
    public class MockMatchDAL : IMatchDA
    {
        List<Match> matches;
        List<Participation> participants;

        public MockMatchDAL()
        {
            matches = new List<Match>();
            matches.Add(new Match(0, 0, 1, 2, 22, 19, MatchStatus.FINISHED, "final"));
        }

        public void AddMatch(Match match)
        {
            matches.Add(match);
        }

        public void UpdateMatch(int matchId, Match match)
        {
            matches[matchId] = match;
        }

        public Match GetMatchById(int matchId)
        {
            return matches[matchId];
        }

        public List<Match> GetAllMatches()
        {
            return matches;
        }

        public List<Match> GetAllMatchesInString()
        {
            return matches;
        }

        public List<Match> GetAllMatchesToString()
        {
            return matches;
        }

        public List<Match> GetAllMatchesByTournamentId(int tournamentId)
        {
            List<Match> list = new List<Match>();

            foreach (Match match in matches)
            {
                if (tournamentId == match.TournamentId)
                {
                    list.Add(match);
                }
            }

            return list;
        }

        public List<Match> GetAllMatchesByUserId(int userId)
        {
            List<Match> list = new List<Match>();

            foreach (Match match in matches)
            {
                if (match.PlayerOne == userId || match.PlayerTwo == userId) 
                {
                    list.Add(match);
                }
            }

            return list;
        }
    }
}
