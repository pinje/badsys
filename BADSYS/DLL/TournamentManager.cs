using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.TournamentBranch;
using Models;

namespace DLL
{
    public class TournamentManager
    {
        ITournamentDA tournament;

        public TournamentManager(ITournamentDA tournament)
        {
            this.tournament = tournament;
        }

        public void AddTournament(Tournament tournament)
        {
            this.tournament.AddTournament(tournament);
        }

        public void UpdateTournament(int tournamentId, Tournament tournament)
        {
            this.tournament.UpdateTournament(tournamentId, tournament);
        }

        public void DeleteTournament(int tournamentId)
        {
            this.tournament.DeleteTournament(tournamentId);
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            return this.tournament.GetTournamentById(tournamentId);
        }

        public List<Tournament> GetAllTournaments()
        {
            return this.tournament.GetAllTournaments();
        }

        public List<List<int>> Ranking(List<Match> match, List<int> participantsId)
        {
            List<List<int>> ranking = new List<List<int>>();

            // check for each participants
            foreach (int participant in participantsId)
            {
                int win = 0;
                int lost = 0;
                int roundfor = 0;
                int roundagainst = 0;
                foreach (Match matchItem in match)
                {
                    if (matchItem.PlayerOne == participant)
                    {
                        if (matchItem.PlayerOneScore > matchItem.PlayerTwoScore)
                        {
                            // player won
                            win++;
                            roundfor += matchItem.PlayerOneScore;
                            roundagainst += matchItem.PlayerTwoScore;
                        }
                        else
                        {
                            // player lost
                            lost++;
                            roundfor += matchItem.PlayerOneScore;
                            roundagainst += matchItem.PlayerTwoScore;
                        }
                    } else if (matchItem.PlayerTwo == participant)
                    {
                        if (matchItem.PlayerTwoScore > matchItem.PlayerOneScore)
                        {
                            // player won
                            win++;
                            roundfor += matchItem.PlayerTwoScore;
                            roundagainst += matchItem.PlayerOneScore;
                        }
                        else
                        {
                            // player lost
                            lost++;
                            roundfor += matchItem.PlayerTwoScore;
                            roundagainst += matchItem.PlayerOneScore;
                        }
                    } else
                    {
                        // not in the match
                    }
                }
                ranking.Add(new List<int> { participant, win, lost, roundfor, roundagainst });
            }

            List<List<int>> rankingOrdered = new List<List<int>>();
            rankingOrdered = ranking.OrderByDescending(x => x[1]).ThenBy(x => (x[3] - x[4])).ToList();
            return rankingOrdered;
        }
    }
}
