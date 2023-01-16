namespace Tournamint_BackEnd.Models
{
    public class Match
    {
        public int MatchId { get; set; } //Id
        public int TournamentId { get; set; }
        public string? PlayerOne { get; set; }
        public string? PlayerTwo { get; set; }
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }
    }
}
