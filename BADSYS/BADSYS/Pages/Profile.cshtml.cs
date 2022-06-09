using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using DLL;
using DAL.UserBranch;
using DAL.ParticipationBranch;
using DAL.TournamentBranch;

namespace BADSYS.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public List<Participation> Participations { get; set; }
        [BindProperty]
        public List<Tournament> TournamentsInformation { get; set; }

        public void OnGet(int userid)
        {
            // get user info
            UserManager userManager = new UserManager(new UserDAL());
            User = userManager.GetUser(userid);

            // get user participations 
            ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());
            Participations = participationManager.GetAllParticipationByPlayer(userid);

            // get tournament info from the participations list
            TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
            TournamentsInformation = new List<Tournament>();

            foreach (Participation participation in Participations)
            {
                Tournament tournament = tournamentManager.GetTournamentById(participation.TournamentId);
                TournamentsInformation.Add(tournament);
            }
        }
    }
}
