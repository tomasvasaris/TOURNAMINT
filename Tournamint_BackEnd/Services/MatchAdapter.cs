using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Models.Dto;

namespace Tournamint_BackEnd.Services
{
    public class MatchAdapter : IMatchAdapter
    {
        public GetMatchResult Bind(Match Match)
        {
            return new GetMatchResult
            {
                Id = Match.Id,
                TournamentId = Match.TournamentId,
                PlayerOneFirstName = Match.PlayerOneFirstName,
                PlayerOneLastName = Match.PlayerOneLastName,
                PlayerTwoFirstName = Match.PlayerTwoFirstName,
                PlayerTwoLastName = Match.PlayerTwoLastName,
                PlayerOneResult = Match.PlayerOneResult,
                PlayerTwoResult = Match.PlayerTwoResult
            };
        }
        public Match Bind(PostMatchRequest Match)
        {
            return new Match
            {
                TournamentId = Match.TournamentId,
                PlayerOneFirstName = Match.PlayerOneFirstName,
                PlayerOneLastName = Match.PlayerOneLastName,
                PlayerTwoFirstName = Match.PlayerTwoFirstName,
                PlayerTwoLastName = Match.PlayerTwoLastName,
                PlayerOneResult = Match.PlayerOneResult,
                PlayerTwoResult = Match.PlayerTwoResult
            };
        }

        public Match Bind(PutMatchRequest Match)
        {
            return new Match
            {
                Id = Match.Id,
                TournamentId = Match.TournamentId,
                PlayerOneFirstName = Match.PlayerOneFirstName,
                PlayerOneLastName = Match.PlayerOneLastName,
                PlayerTwoFirstName = Match.PlayerTwoFirstName,
                PlayerTwoLastName = Match.PlayerTwoLastName,
                PlayerOneResult = Match.PlayerOneResult,
                PlayerTwoResult = Match.PlayerTwoResult
            };
        }
    }
}
