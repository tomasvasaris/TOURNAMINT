using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Models.DTO;

namespace Tournamint_BackEnd.Services
{
    public class MatchAdapter : IMatchAdapter
    {
        public GetMatchResult Bind(Match match)
        {
            return new GetMatchResult
            {
                MatchId = match.MatchId,
                TournamentId = match.TournamentId,
                PlayerOne = match.PlayerOne,
                PlayerTwo = match.PlayerTwo,
                PlayerOneScore = match.PlayerOneScore,
                PlayerTwoScore = match.PlayerTwoScore,
            };
        }

        public Match Bind(PostMatchRequest match)
        {
            return new Match
            {
                TournamentId = match.TournamentId,
                PlayerOne = match.PlayerOne,
                PlayerTwo = match.PlayerTwo,
                PlayerOneScore = match.PlayerOneScore,
                PlayerTwoScore = match.PlayerTwoScore,
            };
        }

        public Match Bind(PutMatchRequest match)
        {
            return new Match
            {
                MatchId = match.MatchId,
                TournamentId = match.TournamentId,
                PlayerOne = match.PlayerOne,
                PlayerTwo = match.PlayerTwo,
                PlayerOneScore = match.PlayerOneScore,
                PlayerTwoScore = match.PlayerTwoScore,
            };
        }
    }
}