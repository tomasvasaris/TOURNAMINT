using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd.Database.InitialData
{
    public static class MatchInitialData
    {
        public static readonly Match[] DataSeed = new Match[] {
        new Match {
            Id = 1,
            TournamentId = 1,
            PlayerOneFirstName = "Test",
            PlayerOneLastName = "Testovich",
            PlayerTwoFirstName = "John",
            PlayerTwoLastName = "Smith",
            PlayerOneResult = "Win",
            PlayerTwoResult = "Loss"
            },
        new Match {
            Id = 2,
            TournamentId = 1,
            PlayerOneFirstName = "Test",
            PlayerOneLastName = "Testovich",
            PlayerTwoFirstName = "John",
            PlayerTwoLastName = "Smith",
            PlayerOneResult = "Loss",
            PlayerTwoResult = "Win"
            },
        new Match {
            Id = 3,
            TournamentId = 1,
            PlayerOneFirstName = "Test",
            PlayerOneLastName = "Testovich",
            PlayerTwoFirstName = "John",
            PlayerTwoLastName = "Smith",
            PlayerOneResult = "Win",
            PlayerTwoResult = "Loss"
            },
        };
    }
}
