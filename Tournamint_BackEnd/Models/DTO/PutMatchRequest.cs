using System.ComponentModel.DataAnnotations;

namespace Tournamint_BackEnd.Models.Dto
{
    public class PutMatchRequest
    {
        /// <summary>
        /// ID number of the game match
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID number of the tournament where the match was played
        /// </summary>
        public int TournamentId { get; set; }

        /// <summary>
        /// The first name of Player One
        /// </summary>
        public string? WinnerFirstName { get; set; }

        /// <summary>
        /// The last name of Player One
        /// </summary>
        public string? WinnerLastName { get; set; }

        /// <summary>
        /// The first name of Player Two
        /// </summary>
        public string? LoserFirstName { get; set; }

        /// <summary>
        /// The last name of Player Rwo
        /// </summary>
        public string? LoserLastName { get; set; }
    }
}
