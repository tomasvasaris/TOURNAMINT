using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Models.Dto;

namespace Tournamint_BackEnd.Services
{
    public interface IMatchAdapter
    {
        GetMatchResult Bind(Match Match);
        Match Bind(PostMatchRequest Match);
        Match Bind(PutMatchRequest Match);
    }
}