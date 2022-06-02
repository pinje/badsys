using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.MatchBranch;
using Models;

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

        public List<Match> GetAllMatchesToString()
        {
            return this.match.GetAllMatchesToString();
        }

        public List<Match> GetAllMatchesByTournamentId(int tournamentId)
        {
            return this.match.GetAllMatchesByTournamentId(tournamentId);
        }
    }
}
