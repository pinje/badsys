using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.TournamentBranch
{
    public class MockTournamentDAL : ITournamentDA
    {
        List<Tournament> tournaments;

        public MockTournamentDAL()
        {
            tournaments = new List<Tournament>();
            tournaments.Add(new Tournament(0, "this is a tournament", Convert.ToDateTime("05/05/2022"), 
                Convert.ToDateTime("05/05/2022"), 4, 12, "address", TournamentSystem.ROUND_ROBIN, TournamentStatus.UPCOMING));
        }

        public void AddTournament(Tournament tournament)
        {
            tournaments.Add(tournament);
        }

        public void UpdateTournament(int tournamentId, Tournament tournament)
        {
            tournaments[tournamentId] = tournament;
        }

        public void DeleteTournament(int tournamentId)
        {
            tournaments.RemoveAt(tournamentId);
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            return tournaments[tournamentId];
        }

        public List<Tournament> GetAllTournaments()
        {
            return tournaments;
        }
    }
}
