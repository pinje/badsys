using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DAL
{
    public class ParticipationDAL : DAL, IParticipationDA
    {
        public void AddParticipation(Participation participation)
        {
            string sql = "";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>()
            };

            ExecuteInsert(sql, parameters);
        }

        public void DeleteParticipation(Participation participation)
        {
            string sql = "";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>()
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
            throw new NotImplementedException();
        }
        public List<Participation> GetAllParticipationByPlayer(int playerId)
        {
            throw new NotImplementedException();
        }

    }
}
