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
using System.Data;
using System.Globalization;

namespace WindowsForms
{
    public partial class TournamentsForm : Form
    {
        public TournamentsForm()
        {
            InitializeComponent();
            comboBox_tournamentSystem.DataSource = Enum.GetValues(typeof(TournamentSystem));
            DisplayUpdate();
        }

        // add tournament
        private void button_addtournament_Click(object sender, EventArgs e)
        {
            string name = textBox_tournamentname.Text;
            DateTime startDate = DateTime.Parse(dateTimePicker_tournamentStart.Value.ToString());
            DateTime endDate = DateTime.Parse(dateTimePicker_tournamentEnd.Value.ToString());
            int minPlayers = Convert.ToInt16(numericUpDown_tournamentMin.Value);
            int maxPlayers = Convert.ToInt16(numericUpDown_tournamentMax.Value);
            string address = textBox_tournamentAddress.Text;
            TournamentSystem system = (TournamentSystem)comboBox_tournamentSystem.SelectedItem;

            Tournament tournament = new Tournament(name, startDate, endDate, minPlayers, maxPlayers, address, system, TournamentStatus.UPCOMING);
            ValidateTournament(tournament);
        }

        // tournament data entry validation
        public void ValidateTournament(Tournament tournament)
        {
            // validate data annotations
            var errors = ValidateThis.ValidateObject(tournament);

            // check if there are any errors
            bool found = false;
            foreach (var error in errors)
            {
                MessageBox.Show(error.ErrorMessage);
                found = true;
                break;
            }

            // if there are no errors, add the tournament, then display it to the DVG
            if (!found)
            {
                ValidateDateInequality(tournament);
            }
        }

        // check if data is correct (startdate < enddate, min < max players)
        public void ValidateDateInequality(Tournament tournament)
        {
            // check if dates are correct
            int result = DateTime.Compare(tournament.StartDate, tournament.EndDate);
            if (result < 0)
            {
                // start date is earlier than end date = correct
                ValidatePlayerNumberInequality(tournament);
            } else
            {
                // startd date and end date are the same or
                // start date later than end date = not valid
                MessageBox.Show("Error: start date and end date impossible");
            }
        }

        public void ValidatePlayerNumberInequality(Tournament tournament)
        {
            // check if dates are correct
            int result = tournament.MinPlayer - tournament.MaxPlayer;
            if (result < 0)
            {
                // min players is smaller than max players = correct
                TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
                tournamentManager.AddTournament(tournament);
                Success();
            } else if (result == 0)
            {
                // min players and max players are the same 
                // meaning the tournament has a fixed number of players 
                // like a private tournament
                MessageBox.Show("Private tournament: Fixed number of players in this tournament");
                TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
                tournamentManager.AddTournament(tournament);
                Success();
            }
            else
            {
                // min players is greater than max players = not valid
                MessageBox.Show("Error: maximum players must be larger than minimum players");
            }
        }

        public void Success()
        {

            // display data to the corresponding DVG
            DisplayUpdate();

            // popup to notify successful data entry
            MessageBox.Show("Tournament added succesfully");

            // empty all boxes
            emptyTextBox();
        }

        // display data to DVG
        public void DisplayUpdate()
        {
            TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
            List<Tournament> list = tournamentManager.GetAllTournaments();
            mainDVG.DataSource = list;
        }

        // empty text boxes after adding an employee (e.g. new entry)
        public void emptyTextBox()
        {
            // array of all text boxes
            TextBox[] textboxes = { textBox_tournamentname, textBox_tournamentAddress };

            // array of all combo boxes
            ComboBox[] comboboxes = { comboBox_tournamentSystem };

            // array of all datetime boxes
            DateTimePicker[] datetimepicker = { dateTimePicker_tournamentStart, dateTimePicker_tournamentEnd };

            // array of numeric boxes
            NumericUpDown[] numericboxes = { numericUpDown_tournamentMin, numericUpDown_tournamentMax };

            // empty all text boxes
            for (int i = 0; i < 2; i++)
            {
                TextBox myTextBox = textboxes[i];
                myTextBox.Text = string.Empty;
            }

            // empty all combo boxes
            for (int i = 0; i < 1; i++)
            {
                ComboBox myComboBox = comboboxes[i];
                myComboBox.SelectedIndex = -1;
            }

            // empty all datetime boxes
            for (int i = 0; i < 2; i++)
            {
                DateTimePicker myDateTimePickerBox = datetimepicker[i];
                myDateTimePickerBox.Text = string.Empty;
            }

            // empty all numeric boxes
            for (int i = 0; i < 2; i++)
            {
                NumericUpDown myNumericBox = numericboxes[i];
                myNumericBox.Value = 0;
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            // check if any rows are selected
            if (mainDVG.SelectedRows.Count > 0)
            {
                // get tournament id
                int tournamentId = Convert.ToInt16(mainDVG.SelectedRows[0].Cells["Id"].Value);


                TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
                Tournament tournament = tournamentManager.GetTournamentById(tournamentId);

                // edit tournament popup
                EditTournament editTournament = new EditTournament(tournament, tournamentId);
                editTournament.ShowDialog();

                // update DVGs
                DisplayUpdate();
            }
            else
            {
                MessageBox.Show("no tournament selected");
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            // check if any rows are selected
            if (mainDVG.SelectedRows.Count > 0)
            {
                // get tournament id
                int tournamentId = Convert.ToInt16(mainDVG.SelectedRows[0].Cells["Id"].Value);

                TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
                tournamentManager.DeleteTournament(tournamentId);

                // confirmation message
                MessageBox.Show("Tournament deleted succesfully");

                // update DVGs
                DisplayUpdate();
            }
            else
            {
                MessageBox.Show("no tournament selected");
            }
        }
    }
}
