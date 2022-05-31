

namespace WindowsForms
{
    public partial class Main : Form
    {

        private Form selectedForm;

        public Main()
        {
            InitializeComponent();
            ShowTournaments();
        }

        // PAGES
        private void formClear()
        {
            this.panel1.Controls.Clear();

            if (this.selectedForm != null)
                this.selectedForm.Controls.Clear();
        }

        private void ShowTournaments()
        {
            this.formClear();

            TournamentsForm tournamentsForm = new TournamentsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tournamentsForm.FormBorderStyle = FormBorderStyle.None;
            this.selectedForm = tournamentsForm;

            this.panel1.Controls.Add(tournamentsForm);
            tournamentsForm.Show();
        }

        private void ShowMatches()
        {
            this.formClear();

            MatchesForm matchesForm = new MatchesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            matchesForm.FormBorderStyle = FormBorderStyle.None;
            this.selectedForm = matchesForm;

            this.panel1.Controls.Add(matchesForm);
            matchesForm.Show();
        }

        private void button_matchpage_Click(object sender, EventArgs e)
        {
            ShowMatches();
        }

        private void button_tournamentpage_Click(object sender, EventArgs e)
        {
            ShowTournaments();
        }
    }
}