using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using DLL;
using DAL.TournamentBranch;
using DAL.ParticipationBranch;
using DAL.UserBranch;
using DAL.MatchBranch;

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
        [BindProperty]
        public List<Match> AllMatches { get; set; }
        [BindProperty]
        public List<List<string>> AllMatchesInformation { get; set; }
        [BindProperty]
        public List<List<string>> Ranking { get; set; }


        public int userId;
        public int tournamentId;
        public DateTime startDate;

        ParticipationManager participationManager = new ParticipationManager(new ParticipationDAL());

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
            }
            else
            {
                // registration not allowed
                RegistrationAllowed = false;
            }

            // get participants names
            Participants = participationManager.GetParticipantsNameByTournament(tournamentid);

            // get number of current registration 
            ListOfParticipation = participationManager.GetAllParticipationByTournament(tournamentid);
            NumberOfRegistration = ListOfParticipation.Count();


            UserManager userManager = new UserManager(new UserDAL());

            // make user dal get userid by email 
            if (User.Identity.Name != null)
            {
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
            }
            else
            {
                IsRegistered = false;
            }

            // tournament results
            MatchManager matchManager = new MatchManager(new MatchDAL());
            AllMatches = matchManager.GetAllMatchesByTournamentId(tournamentid);
            AllMatches.OrderBy(x => x.Id).ToList();

            AllMatchesInformation = new List<List<string>>();

            // tournament results with player names instead of ids
            foreach (Match match in AllMatches)
            {
                // convert player one id to name
                string playerOneName = userManager.GetUser(match.PlayerOne).FirstName + " " + userManager.GetUser(match.PlayerOne).LastName;
                string playerTwoName = userManager.GetUser(match.PlayerTwo).FirstName + " " + userManager.GetUser(match.PlayerTwo).LastName;

                AllMatchesInformation.Add(new List<string> { match.Stage, playerOneName, match.PlayerOneScore.ToString(), playerTwoName, match.PlayerTwoScore.ToString(),
                match.Status.ToString()});
            }

            // make a ranking
            // make a list of participants
            List<int> participantsId = new List<int>();
            foreach (Participation participation in ListOfParticipation)
            {
                participantsId.Add(participation.PlayerId);
            }

            List<Match> finishedMatches = new List<Match>();
            // filter list to only finished matches
            foreach (Match match in AllMatches)
            {
                if (match.Status == MatchStatus.FINISHED)
                {
                    finishedMatches.Add(match);
                }
            }
            List<List<int>> tempRanking = new List<List<int>>();
            tempRanking = tournamentManager.Ranking(finishedMatches, participantsId);

            Ranking = new List<List<string>>();

            int rank = 1;
            // list of int to string
            foreach (var item in tempRanking)
            {
                // convert player one id to name
                string playerName = userManager.GetUser(item[0]).FirstName + " " + userManager.GetUser(item[0]).LastName;

                // 0 = participant, 1 = # win, 2 = # lost, 3 = roundfor, 4 = roundagainst
                Ranking.Add(new List<string> { rank.ToString(), playerName, item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString() });
                rank++;
            }
        }

        public IActionResult OnPostRegister(int tournamentid, int userid)
        {
            participationManager.AddParticipation(new Participation(userid, tournamentid));
            return RedirectToPage("/Confirmation/Registration");
        }

        public IActionResult OnPostDeregister(int tournamentid, int userid)
        {
            participationManager.DeleteParticipation(new Participation(userid, tournamentid));
            return RedirectToPage("/Confirmation/Deregistration");
        }
    }
}
