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
            participations.Add(new Participation(1, 0));
            participations.Add(new Participation(2, 0));
            participations.Add(new Participation(1, 0));
            participations.Add(new Participation(2, 0));
            participations.Add(new Participation(1, 4));
            participations.Add(new Participation(2, 4));
            participations.Add(new Participation(3, 4));
            participations.Add(new Participation(4, 4));
            participations.Add(new Participation(5, 4));
            participations.Add(new Participation(6, 4));
            participations.Add(new Participation(7, 4));
            participations.Add(new Participation(8, 4));

            participations.Add(new Participation(1, 5));
            participations.Add(new Participation(2, 5));
            participations.Add(new Participation(3, 5));
            participations.Add(new Participation(4, 5));
            participations.Add(new Participation(5, 5));
            participations.Add(new Participation(6, 5));
            participations.Add(new Participation(7, 5));
            participations.Add(new Participation(8, 5));
            participations.Add(new Participation(9, 5));
            participations.Add(new Participation(10, 5));
            participations.Add(new Participation(11, 5));
            participations.Add(new Participation(12, 5));
            participations.Add(new Participation(13, 5));
            participations.Add(new Participation(14, 5));
            participations.Add(new Participation(15, 5));
            participations.Add(new Participation(16, 5));

            participations.Add(new Participation(1, 6));
            participations.Add(new Participation(2, 6));

            participations.Add(new Participation(1, 7));
            participations.Add(new Participation(2, 7));
            participations.Add(new Participation(3, 7));
            participations.Add(new Participation(4, 7));

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
            List<List<string>> filteredList = new List<List<string>>();

            foreach (Participation item in participations)
            {
                if (item.TournamentId == tournamentid)
                {
                    filteredList.Add(new List<string> { item.Id.ToString(), item.PlayerId.ToString()});
                }
            }

            return filteredList;
        }

    }
}
