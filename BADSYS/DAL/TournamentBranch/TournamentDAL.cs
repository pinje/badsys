using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DAL.TournamentBranch
{
    public class TournamentDAL : DAL, ITournamentDA
    {
        public void AddTournament(Tournament tournament)
        {
            string sql = "INSERT INTO sa_tournaments (name, startDate, endDate, minPlayers, maxPlayers, address, system, status) VALUES (@name, @startdate, @enddate," +
                "@min, @max, @address, @system, @status); ";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("name", tournament.Description),
                new KeyValuePair<string, dynamic>("name", tournament.StartDate),
                new KeyValuePair<string, dynamic>("name", tournament.EndDate),
                new KeyValuePair<string, dynamic>("name", tournament.MinPlayer),
                new KeyValuePair<string, dynamic>("name", tournament.MaxPlayer),
                new KeyValuePair<string, dynamic>("name", tournament.Address),
                new KeyValuePair<string, dynamic>("name", tournament.System),
                new KeyValuePair<string, dynamic>("name", tournament.Status)
            };

            ExecuteInsert(sql, parameters);
        }

        public void UpdateTournament(int tournamentId, Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public void DeleteTournament(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public List<Tournament> GetAllTournaments()
        {
            string query = "SELECT * FROM sa_tournaments ORDER BY startDate";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Tournament> tournamentDetails = new List<Tournament>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int tournamentId = Convert.ToInt16(data.Tables[0].Rows[row]["tournamentId"]);

                string name = data.Tables[0].Rows[row]["name"].ToString();
                DateTime startDate = Convert.ToDateTime(data.Tables[0].Rows[row]["startDate"]);
                DateTime endDate = Convert.ToDateTime(data.Tables[0].Rows[row]["endDate"]);

                int minPlayers = Convert.ToInt16(data.Tables[0].Rows[row]["minPlayers"]);
                int maxPlayers = Convert.ToInt16(data.Tables[0].Rows[row]["maxPlayers"]);

                string address = data.Tables[0].Rows[row]["address"].ToString();
                TournamentSystem system = (TournamentSystem)data.Tables[0].Rows[row]["system"];
                TournamentStatus status = (TournamentStatus)data.Tables[0].Rows[row]["status"];

                tournamentDetails.Add(new Tournament(tournamentId, name, startDate, endDate, minPlayers, maxPlayers, address, system, status));
            }

            return tournamentDetails;

        }
    }
}
