using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DAL.MatchBranch
{
    public class MatchDAL : DAL, IMatchDA
    {
        public void AddMatch(Match match)
        {
            string query = "INSERT INTO sa_matches (tournament, playerOne, playerTwo, playerOneScore, playerTwoScore, status, stage) " +
                "VALUES (@tournament, @playerone, @playertwo, @playeronescore, @playertwoscore, @status, @stage); ";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("tournament", match.TournamentId),
                new KeyValuePair<string, dynamic>("playerone", match.PlayerOne),
                new KeyValuePair<string, dynamic>("playertwo", match.PlayerTwo),
                new KeyValuePair<string, dynamic>("playeronescore", match.PlayerOneScore),
                new KeyValuePair<string, dynamic>("playertwoscore", match.PlayerTwoScore),
                new KeyValuePair<string, dynamic>("status", match.Status),
                new KeyValuePair<string, dynamic>("stage", match.Stage)
            };

            ExecuteInsert(query, parameters);
        }

        public void UpdateMatch(int matchId, Match match)
        {
            string query = "UPDATE sa_matches SET playerOne = @playerone, playerTwo = @playertwo, playerOneScore = @playeronescore, " +
                "playerTwoScore = @playertwoscore, status = @status, stage = @stage WHERE matchId = @matchid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("playerone", match.PlayerOne),
                new KeyValuePair<string, dynamic>("playertwo", match.PlayerTwo),
                new KeyValuePair<string, dynamic>("playeronescore", match.PlayerOneScore),
                new KeyValuePair<string, dynamic>("playertwoscore", match.PlayerTwoScore),
                new KeyValuePair<string, dynamic>("status", match.Status),
                new KeyValuePair<string, dynamic>("stage", match.Stage),
                new KeyValuePair<string, dynamic>("matchid", matchId)
            };

            ExecuteInsert(query, parameters);
        }

        public Match GetMatchById(int matchid)
        {
            string query = "SELECT matchId, tournament, playerOne, playerTwo, playerOneScore, playerTwoScore, status, stage " +
                "FROM sa_matches" +
                "WHERE matchId = @matchid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("matchid", matchid)
            };

            DataSet data = ExecuteSql(query, parameters);

            if (data != null)
            {
                int id = Convert.ToInt16(data.Tables[0].Rows[0]["matchId"]);
                int tournament = Convert.ToInt16(data.Tables[0].Rows[0]["tournament"]);
                int playerOne = Convert.ToInt16(data.Tables[0].Rows[0]["playerOne"]);
                int playerTwo = Convert.ToInt16(data.Tables[0].Rows[0]["playerTwo"]);
                int playerOneScore = Convert.ToInt16(data.Tables[0].Rows[0]["playerOneScore"]);
                int playerTwoScore = Convert.ToInt16(data.Tables[0].Rows[0]["playerTwoScore"]);
                MatchStatus status = (MatchStatus)data.Tables[0].Rows[0]["status"];
                string stage = data.Tables[0].Rows[0]["stage"].ToString();

                Match match = new Match(id, tournament, playerOne, playerTwo, playerOneScore, playerTwoScore, status, stage);
                return match;
            }
            else
            {
                return null;
            }
        }

        public List<Match> GetAllMatches()
        {
            string query = "SELECT * FROM sa_matches";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Match> matchDetails = new List<Match>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int matchId = Convert.ToInt16(data.Tables[0].Rows[row]["matchId"]);

                int tournament = Convert.ToInt16(data.Tables[0].Rows[row]["tournament"]);

                int playerOne = Convert.ToInt16(data.Tables[0].Rows[row]["playerOne"]);
                int playerTwo = Convert.ToInt16(data.Tables[0].Rows[row]["playerTwo"]);
                int playerOneScore = Convert.ToInt16(data.Tables[0].Rows[row]["playerOneScore"]);
                int playerTwoScore = Convert.ToInt16(data.Tables[0].Rows[row]["playerTwoScore"]);
                MatchStatus status = (MatchStatus)data.Tables[0].Rows[row]["status"];
                string stage = data.Tables[0].Rows[row]["stage"].ToString();


                matchDetails.Add(new Match(matchId, tournament, playerOne, playerTwo, playerOneScore, playerTwoScore, status, stage));
            }

            return matchDetails;
        }

        public List<Match> GetAllMatchesByTournamentId(int tournamentId)
        {
            string query = "SELECT * FROM sa_matches WHERE tournament = @tournamentid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("tournamentid", tournamentId)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Match> matchDetails = new List<Match>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int matchId = Convert.ToInt16(data.Tables[0].Rows[row]["matchId"]);

                int tournament = Convert.ToInt16(data.Tables[0].Rows[0]["tournament"]);
                int playerOne = Convert.ToInt16(data.Tables[0].Rows[0]["playerOne"]);
                int playerTwo = Convert.ToInt16(data.Tables[0].Rows[0]["playerTwo"]);
                int playerOneScore = Convert.ToInt16(data.Tables[0].Rows[0]["playerOneScore"]);
                int playerTwoScore = Convert.ToInt16(data.Tables[0].Rows[0]["playerTwoScore"]);
                MatchStatus status = (MatchStatus)data.Tables[0].Rows[0]["status"];
                string stage = data.Tables[0].Rows[0]["stage"].ToString();


                matchDetails.Add(new Match(matchId, tournament, playerOne, playerTwo, playerOneScore, playerTwoScore, status, stage));
            }

            return matchDetails;
        }
    }
}
