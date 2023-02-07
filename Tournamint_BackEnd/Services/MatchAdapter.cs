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
                WinnerFirstName = Match.WinnerFirstName,
                WinnerLastName = Match.WinnerLastName,
                LoserFirstName = Match.LoserFirstName,
                LoserLastName = Match.LoserLastName
            };
        }
        public Match Bind(PostMatchRequest Match)
        {
            return new Match
            {
                TournamentId = Match.TournamentId,
                WinnerFirstName = Match.WinnerFirstName,
                WinnerLastName = Match.WinnerLastName,
                LoserFirstName = Match.LoserFirstName,
                LoserLastName = Match.LoserLastName
            };
        }

        public Match Bind(PutMatchRequest Match)
        {
            return new Match
            {
                Id = Match.Id,
                TournamentId = Match.TournamentId,
                WinnerFirstName = Match.WinnerFirstName,
                WinnerLastName = Match.WinnerLastName,
                LoserFirstName = Match.LoserFirstName,
                LoserLastName = Match.LoserLastName,
            };
        }
    }
}
