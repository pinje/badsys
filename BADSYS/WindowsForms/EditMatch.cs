using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DLL;
using DAL.MatchBranch;
using DAL.UserBranch;

namespace WindowsForms
{
    public partial class EditMatch : Form
    {
        private int matchId;
        private DataTable users = new DataTable();
        public EditMatch(int matchid, string stage, string playerOneName, string playerTwoName, int playerOneScore, int playerTwoScore, string status)
        {
            InitializeComponent();
            label_currentPlayerOne.Text = "(current: " + playerOneName + " )";
            label_currentPlayerTwo.Text = "(current: " + playerTwoName + " )";


            // get all users and put them into combo boxes
            UserManager userManager = new UserManager(new UserDAL());
            List<User> list = userManager.GetAllUsers();

            users.Clear();
            users.Columns.Add("Display");
            users.Columns.Add("Match ID");

            DataRow row;

            foreach (User user in list)
            {
                row = users.NewRow();
                row["Match ID"] = user.Id;
                row["Display"] = user.FirstName + " " + user.LastName + " - " + user.Id;
                users.Rows.Add(row);
            }

            comboBox_player1.DataSource = users;
            comboBox_player1.DisplayMember = "Display";
            comboBox_player1.ValueMember = "Match ID";

            comboBox_player2.BindingContext = new BindingContext();
            comboBox_player2.DataSource = users;
            comboBox_player2.DisplayMember = "Display";
            comboBox_player2.ValueMember = "Match ID";

            textBox_matchstage.Text = stage;
            numericUpDown_player1score.Value = playerOneScore;
            numericUpDown_player2score.Value = playerTwoScore;
            label_currentstatus.Text = "(current: " + status + " )";
            comboBox_matchStatus.DataSource = Enum.GetValues(typeof(MatchStatus));
            this.matchId = matchid;
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void button_updatematch_Click(object sender, EventArgs e)
        {
            string stage = textBox_matchstage.Text;
            int playerOne = Convert.ToInt16(comboBox_player1.SelectedValue);
            int playerTwo = Convert.ToInt16(comboBox_player2.SelectedValue);
            int playerOneScore = Convert.ToInt16(numericUpDown_player1score.Value);
            int playerTwoScore = Convert.ToInt16(numericUpDown_player2score.Value);
            MatchStatus status = (MatchStatus)comboBox_matchStatus.SelectedItem;

            Match match = new Match(playerOne, playerTwo, playerOneScore, playerTwoScore, status, stage);

            MatchManager matchManager = new MatchManager(new MatchDAL());
            matchManager.UpdateMatch(matchId, match);

            // confirmation message
            MessageBox.Show("Match updated succesfully");

            Close();
        }
    }
}
