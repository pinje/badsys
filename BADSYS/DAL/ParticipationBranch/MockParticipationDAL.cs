using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.ParticipationBranch
{
    public class MockParticipationDAL : IParticipationDA
    {
        List<Participation> participations;

        public MockParticipationDAL()
        {
            participations = new List<Participation>();
            participations.Add(new Participation(1, 2));
            participations.Add(new Participation(2, 2));
            participations.Add(new Participation(2, 3));
        }

        public void AddParticipation(Participation participation)
        {
            participations.Add(participation);
        }

        public void DeleteParticipation(Participation participation)
        {
            participations.RemoveAll(x => x.PlayerId == participation.PlayerId && x.TournamentId == participation.TournamentId);
        }
        public List<Participation> GetAllParticipation()
        {
            return participations;
        }

        public List<Participation> GetAllParticipationByTournament(int tournamentId)
        {
            List<Participation> filteredList = new List<Participation>();

            foreach (Participation item in participations)
            {
                if (item.TournamentId == tournamentId)
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }

        public List<Participation> GetAllParticipationByPlayer(int playerId)
        {
            List<Participation> filteredList = new List<Participation>();

            foreach (Participation item in participations)
            {
                if (item.PlayerId == playerId)
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }

        public List<List<string>> GetParticipantsNameByTournament(int tournamentid)
        {
            throw new NotImplementedException();
        }

    }
}
