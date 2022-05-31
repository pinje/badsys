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
                new KeyValuePair<string, dynamic>("startdate", tournament.StartDate),
                new KeyValuePair<string, dynamic>("enddate", tournament.EndDate),
                new KeyValuePair<string, dynamic>("min", tournament.MinPlayer),
                new KeyValuePair<string, dynamic>("max", tournament.MaxPlayer),
                new KeyValuePair<string, dynamic>("address", tournament.Address),
                new KeyValuePair<string, dynamic>("system", tournament.System),
                new KeyValuePair<string, dynamic>("status", tournament.Status)
            };

            ExecuteInsert(sql, parameters);
        }

        public void UpdateTournament(int tournamentId, Tournament tournament)
        {
            string sql = "UPDATE sa_tournaments SET name = @name, startDate = @startDate, endDate = @endDate, minPlayers = @minPlayers, maxPlayers = @maxPlayers, " +
                "address = @address, system = @system, status = @status WHERE `tournamentId` = @tournamentId";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("name", tournament.Description),
                new KeyValuePair<string, dynamic>("startDate", tournament.StartDate),
                new KeyValuePair<string, dynamic>("endDate", tournament.EndDate),
                new KeyValuePair<string, dynamic>("minPlayers", tournament.MinPlayer),
                new KeyValuePair<string, dynamic>("maxPlayers", tournament.MaxPlayer),
                new KeyValuePair<string, dynamic>("address", tournament.Address),
                new KeyValuePair<string, dynamic>("system", tournament.System),
                new KeyValuePair<string, dynamic>("status", tournament.Status),
                new KeyValuePair<string, dynamic>("tournamentId", tournamentId)
            };

            ExecuteInsert(sql, parameters);
        }

        public void DeleteTournament(int tournamentId)
        {
            string sql = "DELETE FROM sa_tournaments WHERE tournamentId = @tournamentId";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("tournamentId", tournamentId)
            };

            ExecuteInsert(sql, parameters);
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            string sql = "SELECT `tournamentId`, `name`, `startDate`, `endDate`, `minPlayers`, `maxPlayers`, `address`, `system`, `status` FROM sa_tournaments WHERE tournamentId = @tournamentId";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("tournamentId", tournamentId)
            };

            DataSet data = ExecuteSql(sql, parameters);

            if (data != null)
            {
                int id = Convert.ToInt16(data.Tables[0].Rows[0]["tournamentId"]);
                string name = data.Tables[0].Rows[0]["name"].ToString();
                DateTime startDate = Convert.ToDateTime(data.Tables[0].Rows[0]["startDate"]);
                DateTime endDate = Convert.ToDateTime(data.Tables[0].Rows[0]["endDate"]);
                int minPlayers = Convert.ToInt16(data.Tables[0].Rows[0]["minPlayers"]);
                int maxPlayers = Convert.ToInt16(data.Tables[0].Rows[0]["maxPlayers"]);
                string address = data.Tables[0].Rows[0]["address"].ToString();
                TournamentSystem system = (TournamentSystem)data.Tables[0].Rows[0]["system"];
                TournamentStatus status = (TournamentStatus)data.Tables[0].Rows[0]["status"];

                Tournament tournament = new Tournament(id, name, startDate, endDate, minPlayers, maxPlayers, address, system, status);
                return tournament;
            } else
            {
                return null;
            }
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
