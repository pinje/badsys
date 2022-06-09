using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ParticipationBranch;
using Models;

namespace DLL
{
    public class ParticipationManager
    {
        IParticipationDA participation;

        public ParticipationManager(IParticipationDA part)
        {
            participation = part;
        }

        public void AddParticipation(Participation registration)
        {
            participation.AddParticipation(registration);
        }

        public void DeleteParticipation(Participation registration)
        {
            participation.DeleteParticipation(registration);
        }
        public List<Participation> GetAllParticipation()
        {
            return participation.GetAllParticipation();
        }

        public List<Participation> GetAllParticipationByTournament(int tournamentId)
        {
            return participation.GetAllParticipationByTournament(tournamentId);
        }
        public List<Participation> GetAllParticipationByPlayer(int playerId)
        {
            return participation.GetAllParticipationByPlayer(playerId);
        }

        public List<List<string>> GetParticipantsNameByTournament(int tournamentid)
        {
            return participation.GetParticipantsNameByTournament(tournamentid);
        }
    }
}