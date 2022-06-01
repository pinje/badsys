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
            //MatchManager matchManager = new MatchManager(new MatchDAL());
            //List<Match> list = matchManager.GetAllMatches();
            //matchesDVG.DataSource = list;
        }
    }
}
