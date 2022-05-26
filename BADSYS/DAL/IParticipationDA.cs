﻿using Models;

namespace DAL
{
    public interface IParticipationDA
    {
        void AddParticipation(Participation participation);
        void DeleteParticipation(Participation participation);
        List<Participation> GetAllParticipation();
        List<Participation> GetAllParticipationByTournament(int tournamentId);
        List<Participation> GetAllParticipationByPlayer(int playerId);
    }
}
