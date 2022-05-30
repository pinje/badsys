namespace Models
{
    public class Participation
    {
        private int id;
        private int playerId;
        private int tournamentId;

        public Participation(int playerId, int tournamentId)
        {
            this.playerId = playerId;
            this.tournamentId = tournamentId;
        }

        public Participation(int id, int playerId, int tournamentId)
        {
            this.id = id;
            this.playerId = playerId;
            this.tournamentId = tournamentId;
        }

        public int Id { get { return id; } set { id = value; } }
        public int PlayerId { get { return playerId; } set { playerId = value; } }
        public int TournamentId { get { return tournamentId; } set { tournamentId = value; } }
    }
}