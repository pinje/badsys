using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using DLL;
using DAL.UserBranch;
using DAL.ParticipationBranch;
using DAL.TournamentBranch;
using DAL.MatchBranch;

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
        [BindProperty]
        public List<List<string>> MatchesInformation { get; set; }

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

            // get user matches
            MatchManager matchManager = new MatchManager(new MatchDAL());
            List<Match>  matches = matchManager.GetAllMacthesByUserId(userid);
            MatchesInformation = new List<List<string>>();

            // convert all matches data into string data
            foreach (var match in matches)
            {
                // convert tournament id to name
                string tournamentName = tournamentManager.GetTournamentById(match.TournamentId).Description;

                // convert player one id to name
                string playerOneName = userManager.GetUser(match.PlayerOne).FirstName + " " + userManager.GetUser(match.PlayerOne).LastName;
                string playerTwoName = userManager.GetUser(match.PlayerTwo).FirstName + " " + userManager.GetUser(match.PlayerTwo).LastName;

                MatchesInformation.Add(new List<string> { tournamentName, match.Stage, playerOneName, match.PlayerOneScore.ToString(), playerTwoName, match.PlayerTwoScore.ToString(), 
                match.Status.ToString()});
            }

        }
    }
}
