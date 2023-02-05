using Tournamint_BackEnd.Database;
using Tournamint_BackEnd.Models;
using System.Linq.Expressions;

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
            return _context.Matches;
        }
      
        public Match Get(int id)
        {
            return _context.Matches.First(x => x.Id == id);
        }
        
        public IEnumerable<Match> Find(Expression<Func<Match, bool>> predicate)
        {
            return _context.Matches.Where(predicate);
        }

        public int Count()
        {
            return _context.Matches.Count();
        }

        public bool Exist(int id)
        {
            return _context.Matches.Any(x => x.Id == id);
        }

        public int Create(Match entity)
        {
            _context.Matches.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }
        
        public void Update(Match entity)
        {
            _context.Matches.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Match entity)
        {
            _context.Matches.Remove(entity);
            _context.SaveChanges();
        }
    }
}
