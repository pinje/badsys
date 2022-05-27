using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.TournamentBranch;
using Models;

namespace DLL
{
    public class TournamentManager
    {
        ITournamentDA tournament;

        public TournamentManager(ITournamentDA tournament)
        {
            this.tournament = tournament;
        }

        public void AddTournament(Tournament tournament)
        {
            this.tournament.AddTournament(tournament);
        }

        public void UpdateTournament(int tournamentId, Tournament tournament)
        {
            this.tournament.UpdateTournament(tournamentId, tournament);
        }

        public void DeleteTournament(int tournamentId)
        {
            this.tournament.DeleteTournament(tournamentId);
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            return this.tournament.GetTournamentById(tournamentId);
        }

        public List<Tournament> GetAllTournaments()
        {
            return this.tournament.GetAllTournaments();
        }
    }
}
