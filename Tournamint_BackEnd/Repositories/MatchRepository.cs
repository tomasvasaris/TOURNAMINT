using System.Linq.Expressions;
using Tournamint_BackEnd.Database;
using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly MatchContext _context;


        public MatchRepository(MatchContext context)
        {
            _context = context;
        }

        public IEnumerable<Match> All()
        {
            return _context.matches;
        }

        public Match Get(int id)
        {
            return _context.matches.First(x => x.MatchId == id);
        }

        public IEnumerable<Match> Find(Expression<Func<Match, bool>> predicate)
        {
            return _context.matches.Where(predicate);
        }

        public int Count()
        {
            return _context.matches.Count();
        }

        public bool Exists(int id)
        {
            return _context.matches.Any(x => x.MatchId == id);
        }

        public int Create(Match entity)
        {
            _context.matches.Add(entity);
            _context.SaveChanges();
            return entity.MatchId;
        }

        public void Update(Match entity)
        {
            _context.matches.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Match entity)
        {
            _context.matches.Remove(entity);
            _context.SaveChanges();
        }
    }
}
