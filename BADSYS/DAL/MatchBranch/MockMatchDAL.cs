using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.MatchBranch
{
    public class MockMatchDAL : IMatchDA
    {
        List<Match> matches;

        public MockMatchDAL()
        {
            matches = new List<Match>();
            matches.Add(new Match(0, 0, "1", "2", 22, 19, MatchStatus.FINISHED, "final"));
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
    }
}
