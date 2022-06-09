using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using DLL;
using DAL.TournamentBranch;
using DAL.ParticipationBranch;
using DAL.UserBranch;

namespace BADSYS.Pages
{
    public class TournamentModel : PageModel
    {
        [BindProperty]
        public Tournament Tournament { get; set; }
        [BindProperty]
        public int NumberOfRegistration { get; set; }
        [BindProperty]
        public List<Participation> ListOfParticipation { get; set; }
        [BindProperty]
        public bool IsRegistered { get; set; }
        [BindProperty]
        public bool RegistrationAllowed { get; set; }
        [BindProperty]
        public DateTime CurrentDate { get; set; }
        [BindProperty]
        public List<List<string>> Participants { get; set; }


        public int userId;
        public int tournamentId;
        public DateTime startDate;

        public void OnGet(int tournamentid)
        {
            ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());
            tournamentId = tournamentid;
            TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
            Tournament = tournamentManager.GetTournamentById(tournamentid);

            // check the current date and see if registration is allowed (max 1 week before)
            // get current date
            CurrentDate = DateTime.Now;
            // get start date of the tournament
            startDate = Tournament.StartDate;
            // check if current date is comapared to start date
            // compare current date and (start date - 7 days)
            int dateCompare = DateTime.Compare(CurrentDate, startDate.AddDays(-7));
            if (dateCompare < 0)
            {
                // allow registration
                RegistrationAllowed = true;
            } else
            {
                // registration not allowed
                RegistrationAllowed = false;
            }

            // get participants names
            Participants = participationManager.GetParticipantsNameByTournament(tournamentid);

            // get number of current registration 
            ListOfParticipation = participationManager.GetAllParticipationByTournament(tournamentid);
            NumberOfRegistration = ListOfParticipation.Count();

            // make user dal get userid by email 
            if (User.Identity.Name != null)
            {
                UserManager userManager = new UserManager(new UserDAL());
                userId = userManager.GetUserIdByEmail(User.Identity.Name);
            }

            // check if user has already registered for the tournament
            List<Participation> userParticipation = participationManager.GetAllParticipationByPlayer(userId);
            if (userParticipation.Count != 0)
            {
                foreach (var item in userParticipation)
                {
                    if (userParticipation.Any(x => x.TournamentId == tournamentid))
                    {
                        // already registered
                        IsRegistered = true;
                    }
                    else
                    {
                        IsRegistered = false;
                    }
                }
            } else
            {
                IsRegistered = false;
            }
        }

        public IActionResult OnPostRegister(int tournamentid, int userid)
        {
            ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());
            participationManager.AddParticipation(new Participation(userid, tournamentid));
            return RedirectToPage("/Confirmation/Registration");
        }

        public IActionResult OnPostDeregister(int tournamentid, int userid)
        {
            ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());
            participationManager.DeleteParticipation(new Participation(userid, tournamentid));
            return RedirectToPage("/Confirmation/Deregistration");
        }
    }
}
