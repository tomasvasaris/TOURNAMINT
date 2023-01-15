using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd.Database.InitialData
{
    public class MatchInitialData
    {
        public static readonly Match[] DataSeed = new Match[] {
        new Match {
            MatchId = -1,
            TournamentId = -1,
            PlayerOne = "TestPlayerOne",
            PlayerTwo = "TestPlayerTwo",
            PlayerOneScore = 0,
            PlayerTwoScore = 1
            }
        };
    }
}
