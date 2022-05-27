using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Match
    {
        private int id;
        private int tournamentId;
        private string playerOne;
        private string playerTwo;
        private int playerOneScore;
        private int playerTwoScore;
        private MatchStatus status;
        private string stage;

        public Match(int id, int tournamentId, string playerOne, string playerTwo, int playerOneScore, int playerTwoScore, MatchStatus status, string stage)
        {
            this.id = id;
            this.tournamentId = tournamentId;
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            this.playerOneScore = playerOneScore;
            this.playerTwoScore = playerTwoScore;
            this.status = status;
            this.stage = stage;
        }

        public int Id { get { return id; } set { id = value; } }
        public int TournamentId { get { return tournamentId; } set { tournamentId = value; } }
        public string PlayerOne { get { return playerOne; } set { playerOne = value; } }
        public string PlayerTwo { get { return playerTwo; } set { playerTwo = value; } }
        public int PlayerOneScore { get { return playerOneScore; } set { playerOneScore = value; } }
        public int PlayerTwoScore { get { return playerTwoScore; } set { playerTwoScore = value; } }
        public MatchStatus Status { get { return status; } set { status = value; } }
        public string Stage { get { return stage; } set { stage = value; } }
    }
}
