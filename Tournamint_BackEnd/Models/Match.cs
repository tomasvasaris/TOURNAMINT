using Tournamint_BackEnd.Models.Dto;

namespace Tournamint_BackEnd.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public string? WinnerFirstName { get; set; }
        public string? WinnerLastName { get; set; }
        public string? LoserFirstName { get; set; }
        public string? LoserLastName { get; set; }
    }
}
