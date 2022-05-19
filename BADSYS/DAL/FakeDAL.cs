using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class FakeDAL : IParticipationDA
    {
        List<Participation> participations;

        public FakeDAL()
        {
            participations = new List<Participation>();
            participations.Add(new Participation(1, 2));
            participations.Add(new Participation(2, 3));
        }

        public Participation AddParticipation(Participation participation)
        {
            throw new NotImplementedException();
        }

        public List<Participation> GetParticipations()
        {
            return participations;
        }

        void IParticipationDA.AddParticipation(Participation participation)
        {
            throw new NotImplementedException();
        }
    }
}
