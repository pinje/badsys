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

            DataRow row;

            foreach (Match match in list)
            {
                row = matches.NewRow();
                row["Match ID"] = match.Id;
                row["Tournament Name"] = tournamentManager.GetTournamentById(match.TournamentId).Description;
                row["Stage"] = match.Stage;
                row["Player 1 Name"] = userManager.GetUser(match.PlayerOne).FirstName + " " + userManager.GetUser(match.PlayerOne).LastName;
                row["Player 2 Name"] = userManager.GetUser(match.PlayerTwo).FirstName + " " + userManager.GetUser(match.PlayerTwo).LastName;
                row["Player 1 Score"] = match.PlayerOneScore;
                row["Player 2 Score"] = match.PlayerTwoScore;
                row["Status"] = match.Status;
                matches.Rows.Add(row);
            }
            matchesDVG.DataSource = matches;
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            // check if any rows are selected
            if (matchesDVG.SelectedRows.Count > 0)
            {
                // get match id
                int matchId = Convert.ToInt16(matchesDVG.SelectedRows[0].Cells["Match Id"].Value);

                // get player names
                string playerOneName = matchesDVG.SelectedRows[0].Cells["Player 1 Name"].Value.ToString();
                string playerTwoName = matchesDVG.SelectedRows[0].Cells["Player 2 Name"].Value.ToString();

                // get scores
                int playerOneScore = Convert.ToInt16(matchesDVG.SelectedRows[0].Cells["Player 1 Score"].Value);
                int playerTwoScore = Convert.ToInt16(matchesDVG.SelectedRows[0].Cells["Player 2 Score"].Value);

                string status = matchesDVG.SelectedRows[0].Cells["Status"].Value.ToString();

                string stage = matchesDVG.SelectedRows[0].Cells["Stage"].Value.ToString();

                // edit match popup
                EditMatch editMatch = new EditMatch(matchId, stage, playerOneName, playerTwoName, playerOneScore, playerTwoScore, status);
                editMatch.ShowDialog();

                // update DVGs
                DisplayUpdate();
            }
            else
            {
                MessageBox.Show("no match selected");
            }
        }
    }
}
