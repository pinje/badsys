using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
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

        public void AddParticipant(Participation registration)
        {
            participation.AddParticipation(new Participation(1, 2));
        }
    }
}