using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DLL;
using DAL.TournamentBranch;
using Models;

namespace BADSYS.Pages
{
    public class TournamentsModel : PageModel
    {
        [BindProperty]
        public List<Tournament> tournaments { get; set; }
        public void OnGet()
        {
            TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
            tournaments = tournamentManager.GetAllTournaments();
        }
    }
}
