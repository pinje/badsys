using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.TournamentBranch
{
    public interface ITournamentDA
    {
        void AddTournament(Tournament tournament);
        void UpdateTournament(int tournamentId, Tournament tournament);
        void DeleteTournament(int tournamentId);
        Tournament GetTournamentById(int tournamentId);
        List<Tournament> GetAllTournaments();
    }
}
