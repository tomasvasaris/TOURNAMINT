using Tournamint_BackEnd.Database;
using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd.Repositories
{
    public interface IUserMatchRepository
    {
        IEnumerable<Match> Get(int userId);
    }
    public class UserMatchRepository: IUserMatchRepository
    {
        private readonly MatchContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserMatchRepository(MatchContext context, 
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Match> Get(int userId)
        {
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);

            var entities =
                from MatchUser in _context.MatchUser.Where(x => x.LocalUserId == currentUserId)
                join Match in _context.Matches on MatchUser.Id equals Match.Id
                where MatchUser.LocalUserId == userId
                select Match;

            return entities;
        }
    }
}