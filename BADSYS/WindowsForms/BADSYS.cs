using Models;
using DLL;
using DAL.TournamentBranch;
using System.Data;

namespace WindowsForms
{
    public partial class BADSYS : Form
    {
        public BADSYS()
        {
            InitializeComponent();
            comboBox_tournamentSystem.DataSource = Enum.GetValues(typeof(TournamentSystem));
            DisplayUpdate();
        }

        // add tournament
        private void button_addtournament_Click(object sender, EventArgs e)
        {
            string name = textBox_tournamentname.ToString();
            DateTime startDate = Convert.ToDateTime(dateTimePicker_tournamentStart);
            DateTime endDate = Convert.ToDateTime(dateTimePicker_tournamentEnd);
            int minPlayers = Convert.ToInt16(numericUpDown_tournamentMin);
            int maxPlayers = Convert.ToInt16(numericUpDown_tournamentMax);
            string address = textBox_tournamentAddress.ToString();
            TournamentSystem system = (TournamentSystem)comboBox_tournamentSystem.SelectedItem;

            Tournament tournament = new Tournament(3, name, startDate, endDate, minPlayers, maxPlayers, address, system, TournamentStatus.UPCOMING);
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
                TournamentManager tournamentManager = new TournamentManager(new TournamentDAL());
                tournamentManager.AddTournament(tournament);
                Success();
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
            TextBox[] textboxes = { textBox_tournamentname, textBox_tournamentAddress};

            // array of all combo boxes
            ComboBox[] comboboxes = { comboBox_tournamentSystem };

            // array of all datetime boxes
            DateTimePicker[] datetimepicker = { dateTimePicker_tournamentStart, dateTimePicker_tournamentEnd };

            // array of numeric boxes
            NumericUpDown[] numericboxes = { numericUpDown_tournamentMin, numericUpDown_tournamentMax };

            // empty all text boxes
            for (int i = 0; i < 3; i++)
            {
                TextBox myTextBox = textboxes[i];
                myTextBox.Text = string.Empty;
            }

            // empty all combo boxes
            for (int i = 0; i < 2; i++)
            {
                ComboBox myComboBox = comboboxes[i];
                myComboBox.SelectedIndex = -1;
            }

            // empty all datetime boxes
            for (int i = 0; i < 3; i++)
            {
                DateTimePicker myDateTimePickerBox = datetimepicker[i];
                myDateTimePickerBox.Text = string.Empty;
            }

            // empty all numeric boxes
            for (int i = 0; i < 3; i++)
            {
                NumericUpDown myNumericBox = numericboxes[i];
                myNumericBox.Value = 0;
            }
        }
    }
}