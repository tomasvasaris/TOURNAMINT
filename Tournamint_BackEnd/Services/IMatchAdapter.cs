using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Models.DTO;

namespace Tournamint_BackEnd.Services
{
    public interface IMatchAdapter
    {

        GetMatchResult Bind(Match match);
        Match Bind(PostMatchRequest match);
        Match Bind(PutMatchRequest match);
    }
}
