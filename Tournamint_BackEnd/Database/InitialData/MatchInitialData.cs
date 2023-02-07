using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd.Database.InitialData
{
    public static class MatchInitialData
    {
        public static readonly Match[] DataSeed = new Match[] {
        new Match {
            Id = 1,
            TournamentId = 0,
            WinnerFirstName = "Test",
            WinnerLastName = "Testovich",
            LoserFirstName = "John",
            LoserLastName = "Smith"
            },
        new Match {
            Id = 2,
            TournamentId = 0,
            WinnerFirstName = "Test",
            WinnerLastName = "Testovich",
            LoserFirstName = "John",
            LoserLastName = "Smith"
            },
        new Match {
            Id = 3,
            TournamentId = 0,
            WinnerFirstName = "Test",
            WinnerLastName = "Testovich",
            LoserFirstName = "John",
            LoserLastName = "Smith"
            },
        };
    }
}
