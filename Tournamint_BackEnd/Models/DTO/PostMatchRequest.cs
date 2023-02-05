using System.ComponentModel.DataAnnotations;

namespace Tournamint_BackEnd.Models.Dto
{
    public class PostMatchRequest
    {
        /// <summary>
        /// ID number of the tournament where the match was played
        /// </summary>
        public int TournamentId { get; set; }

        /// <summary>
        /// The first name of Player One
        /// </summary>
        public string? PlayerOneFirstName { get; set; }

        /// <summary>
        /// The last name of Player One
        /// </summary>
        public string? PlayerOneLastName { get; set; }

        /// <summary>
        /// The first name of Player Two
        /// </summary>
        public string? PlayerTwoFirstName { get; set; }

        /// <summary>
        /// The last name of Player Rwo
        /// </summary>
        public string? PlayerTwoLastName { get; set; }

        /// <summary>
        /// Match Score of Player 01
        /// </summary>
        public string? PlayerOneResult { get; set; }

        /// <summary>
        /// Match Score of Player 02
        /// </summary>
        public string? PlayerTwoResult { get; set; }
    }
}
