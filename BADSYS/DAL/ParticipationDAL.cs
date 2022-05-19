using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

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

    }
}
