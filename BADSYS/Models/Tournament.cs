using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tournament
    {
        private int id;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int minPlayer;
        private int maxPlayer;
        private string address;
        private TournamentSystem system;
        private TournamentStatus status;

        public Tournament(int id, string description, DateTime startDate, DateTime endDate, int minPlayer, int maxPlayer, string address, TournamentSystem system, TournamentStatus status)
        {
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minPlayer = minPlayer;
            this.maxPlayer = maxPlayer;
            this.address = address;
            this.system = system;
            this.status = status;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Description { get { return description; } set { description = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public int MinPlayer { get { return minPlayer; } set { minPlayer = value; } }
        public int MaxPlayer { get { return maxPlayer; } set { maxPlayer = value; } }
        public string Address { get { return address; } set { address = value; } }
        public TournamentSystem System { get { return system; } set { system = value; } }
        public TournamentStatus Status { get { return status; } set { status = value; } }
    }
}
