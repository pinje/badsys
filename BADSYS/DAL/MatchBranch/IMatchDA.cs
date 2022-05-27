using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.MatchBranch
{
    public interface IMatchDA
    {
        void AddMatch(Match match);
        void UpdateMatch(int matchId, Match match);
        Match GetMatchById(int matchId);
        List<Match> GetAllMatches();
        List<Match> GetAllMatchesByTournamentId(int tournamentId);
    }
}
