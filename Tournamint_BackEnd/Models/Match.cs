using Tournamint_BackEnd.Models.Dto;

namespace Tournamint_BackEnd.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public string? PlayerOneFirstName { get; set; }
        public string? PlayerOneLastName { get; set; }
        public string? PlayerTwoFirstName { get; set; }
        public string? PlayerTwoLastName { get; set; }
        public string? PlayerOneResult { get; set; }
        public string? PlayerTwoResult { get; set; }
    }
}
