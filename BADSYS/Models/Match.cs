﻿using System;
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
        private string tournamentName;
        private string playerOne;
        private string playerTwo;
        private int playerOneId;
        private int playerTwoId;
        private int playerOneScore;
        private int playerTwoScore;
        private MatchStatus status;
        private string stage;

        public Match(int id, string tournamentName, string playerOne, string playerTwo, int playerOneScore, int playerTwoScore, MatchStatus status, string stage)
        {
            this.id = id;
            this.tournamentName = tournamentName;
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            this.playerOneScore = playerOneScore;
            this.playerTwoScore = playerTwoScore;
            this.status = status;
            this.stage = stage;
        }

        public Match(int id, int tournamentId, int playerOne, int playerTwo, int playerOneScore, int playerTwoScore, MatchStatus status, string stage)
        {
            this.id = id;
            this.tournamentId = tournamentId;
            this.playerOneId = playerOne;
            this.playerTwoId = playerTwo;
            this.playerOneScore = playerOneScore;
            this.playerTwoScore = playerTwoScore;
            this.status = status;
            this.stage = stage;
        }

        public Match(int tournamentId, int playerOne, int playerTwo, int playerOneScore, int playerTwoScore, MatchStatus status, string stage)
        {
            this.tournamentId = tournamentId;
            this.playerOneId = playerOne;
            this.playerTwoId = playerTwo;
            this.playerOneScore = playerOneScore;
            this.playerTwoScore = playerTwoScore;
            this.status = status;
            this.stage = stage;
        }

        public int Id { get { return id; } set { id = value; } }
        public int TournamentId { get { return tournamentId; } set { tournamentId = value; } }
        public string PlayerOne { get { return playerOne; } set { playerOne = value; } }
        public string PlayerTwo { get { return playerTwo; } set { playerTwo = value; } }
        public int PlayerOneId { get { return playerOneId; } set { playerOneId = value; } }
        public int PlayerTwoId { get { return playerTwoId; } set { playerTwoId = value; } } 
        public int PlayerOneScore { get { return playerOneScore; } set { playerOneScore = value; } }
        public int PlayerTwoScore { get { return playerTwoScore; } set { playerTwoScore = value; } }
        public MatchStatus Status { get { return status; } set { status = value; } }
        public string Stage { get { return stage; } set { stage = value; } }
    }
}
