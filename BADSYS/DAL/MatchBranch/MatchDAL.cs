using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.MatchBranch
{
    public class MatchDAL : DAL, IMatchDA
    {
        public void AddMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void UpdateMatch(int matchId, Match match)
        {
            throw new NotImplementedException();
        }

        public Match GetMatchById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Match> GetAllMatches()
        {
            throw new NotImplementedException();
        }

        public List<Match> GetAllMatchesByTournamentId(int tournamentId)
        {
            throw new NotImplementedException();
        }

    }
}
