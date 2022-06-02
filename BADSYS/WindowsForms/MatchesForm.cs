using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL;
using Models;
using DAL.MatchBranch;
using DAL.UserBranch;
using DAL.TournamentBranch;

namespace WindowsForms
{
    public partial class MatchesForm : Form
    {
        public MatchesForm()
        {
            InitializeComponent();
             DisplayUpdate();
        }

        public void DisplayUpdate()
        {
            MatchManager matchManager = new MatchManager(new MatchDAL());
            TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
            UserManager userManager = new UserManager(new UserDAL());

            List<Match> list = matchManager.GetAllMatches();
            DataTable matches = new DataTable();
            matches.Clear();

            matches.Columns.Add("Match ID");
            matches.Columns.Add("Tournament Name");
            matches.Columns.Add("Stage");
            matches.Columns.Add("Player 1 Name");
            matches.Columns.Add("Player 2 Name");
            matches.Columns.Add("Player 1 Score");
            matches.Columns.Add("Player 2 Score");
            matches.Columns.Add("Status");

            DataRow row = matches.NewRow();

            foreach (Match match in list)
            {
                row["Match ID"] = match.Id;
                row["Tournament Name"] = tournamentManager.GetTournamentById(match.TournamentId).Description;
                row["Stage"] = match.Stage;
                row["Player 1 Name"] = ToUpperFirstLetter(userManager.GetUser(match.PlayerOne).FirstName) + " " +
                    ToUpperFirstLetter(userManager.GetUser(match.PlayerOne).LastName);
                row["Player 2 Name"] = ToUpperFirstLetter(userManager.GetUser(match.PlayerTwo).FirstName) + " " +
                    ToUpperFirstLetter(userManager.GetUser(match.PlayerTwo).LastName);
                row["Player 1 Score"] = match.PlayerOneScore;
                row["Player 2 Score"] = match.PlayerTwoScore;
                row["Status"] = (MatchStatus)match.Status;
                matches.Rows.Add(row);
            }
            matchesDVG.DataSource = matches;
        }

        public string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }
    }
}
