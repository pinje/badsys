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
using DAL.TournamentBranch;

namespace WindowsForms
{
    public partial class EditTournament : Form
    {
        private int tournamentId;
        public EditTournament(Tournament tournament, int tournamentId)
        {
            InitializeComponent();

            comboBox_tournamentSystem.DataSource = Enum.GetValues(typeof(TournamentSystem));
            comboBox_tournamentStatus.DataSource = Enum.GetValues(typeof(TournamentStatus));
            this.tournamentId = tournamentId;

            textBox_tournamentname.Text = tournament.Description.ToString();
            dateTimePicker_tournamentStart.Value = DateTime.Parse(tournament.StartDate.ToString());
            dateTimePicker_tournamentEnd.Value = DateTime.Parse(tournament.EndDate.ToString());
            numericUpDown_tournamentMin.Value = Convert.ToInt16(tournament.MinPlayer);
            numericUpDown_tournamentMax.Value = Convert.ToInt16(tournament.MaxPlayer);
            textBox_tournamentAddress.Text = tournament.Address.ToString();
            comboBox_tournamentSystem.SelectedItem = tournament.System;
            comboBox_tournamentStatus.SelectedItem = tournament.Status;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_updatetournament_Click(object sender, EventArgs e)
        {
            string name = textBox_tournamentname.Text;
            DateTime startDate = DateTime.Parse(dateTimePicker_tournamentStart.Value.ToString());
            DateTime endDate = DateTime.Parse(dateTimePicker_tournamentEnd.Value.ToString());
            int minPlayers = Convert.ToInt16(numericUpDown_tournamentMin.Value);
            int maxPlayers = Convert.ToInt16(numericUpDown_tournamentMax.Value);
            string address = textBox_tournamentAddress.Text;
            TournamentSystem system = (TournamentSystem)comboBox_tournamentSystem.SelectedItem;
            TournamentStatus status = (TournamentStatus)comboBox_tournamentStatus.SelectedItem;

            Tournament tournament = new Tournament(name, startDate, endDate, minPlayers, maxPlayers, address, system, status);

            TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
            tournamentManager.UpdateTournament(tournamentId, tournament);

            // confirmation message
            MessageBox.Show("Tournament updated succesfully");

            Close();
        }
    }
}
