﻿namespace Tournamint_BackEnd.Models.DTO
{
    public class PutMatchRequest
    {
        /// <summary>
        /// ID number of the tournament where the match was played
        /// </summary>
        public int TournamentId { get; set; }
        /// <summary>
        /// Name_Surname string of Player 01
        /// </summary>
        public string? PlayerOne { get; set; }
        /// <summary>
        /// Name_Surname string of Player 02
        /// </summary>
        public string? PlayerTwo { get; set; }
        /// <summary>
        /// Match Score of Player 01
        /// </summary>
        public int PlayerOneScore { get; set; }
        /// <summary>
        /// Match Score of Player 02
        /// </summary>
        public int PlayerTwoScore { get; set; }
    }
}