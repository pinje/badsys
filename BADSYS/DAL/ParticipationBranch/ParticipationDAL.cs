using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DAL.ParticipationBranch
{
    public class ParticipationDAL : DAL, IParticipationDA
    {
        public void AddParticipation(Participation participation)
        {
            string sql = "INSERT INTO sa_participations (playerId, tournamentId) VALUES (@playerid, @tournamentid); ";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("playerid", participation.PlayerId),
                new KeyValuePair<string, dynamic>("tournamentid", participation.TournamentId)
            };

            ExecuteInsert(sql, parameters);
        }

        public void DeleteParticipation(Participation participation)
        {
            string sql = "DELETE FROM sa_participations WHERE playerId = @playerid AND tournamentId = @tournamentid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("playerid", participation.PlayerId),
                new KeyValuePair<string, dynamic>("tournamentid", participation.TournamentId),
            };

            ExecuteInsert(sql, parameters);
        }

        public List<Participation> GetAllParticipation()
        {
            string sql = "";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(sql, parameters);
            List<Participation> participationList = new List<Participation>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {


                int playerId = Convert.ToInt32(data.Tables[0].Rows[row]["playerId"]);
                int tournamentId = Convert.ToInt32(data.Tables[0].Rows[row]["tournamentId"]);

                Participation participation = new Participation(playerId, tournamentId);

                participationList.Add(participation);
            }

            return participationList;
        }

        public List<Participation> GetAllParticipationByTournament(int tournamentId)
        {
            string query = "SELECT * FROM sa_participations WHERE tournamentId = @tournamentid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("tournamentid", tournamentId)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Participation> participationDetails = new List<Participation>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int playerId = Convert.ToInt16(data.Tables[0].Rows[row]["playerId"]);
                int tournament = Convert.ToInt16(data.Tables[0].Rows[row]["tournamentId"]);

                participationDetails.Add(new Participation(playerId, tournament));
            }

            return participationDetails;
        }
        public List<Participation> GetAllParticipationByPlayer(int player)
        {
            string query = "SELECT * FROM sa_participations WHERE playerId = @playerId";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("playerId", player)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Participation> participationDetails = new List<Participation>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int playerId = Convert.ToInt16(data.Tables[0].Rows[row]["playerId"]);
                int tournament = Convert.ToInt16(data.Tables[0].Rows[row]["tournamentId"]);

                participationDetails.Add(new Participation(playerId, tournament));
            }

            return participationDetails;
        }

        public List<List<string>> GetParticipantsNameByTournament(int tournamentid) 
        {
            string query = "SELECT p.participationId, u.userId, u.firstName, u.lastName " +
                "FROM sa_participations p " +
                "INNER JOIN sa_users u ON u.userId = p.playerId " +
                "WHERE tournamentId = @tournamentid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("tournamentid", tournamentid)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<List<string>> userDetails = new List<List<string>>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string participationId = data.Tables[0].Rows[row]["participationId"].ToString();
                string userId = data.Tables[0].Rows[row]["userId"].ToString();

                string firstName = data.Tables[0].Rows[row]["firstName"].ToString();
                string lastName = data.Tables[0].Rows[row]["lastName"].ToString();

                List<string> list = new List<string> { participationId, userId, firstName, lastName };
                userDetails.Add(list);
            }

            return userDetails;
        }
    }
}
