using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;

namespace Wsei.Matches.Infrastructure.Repository
{
    public class CountryRepository : IRepository<Country>
    {
        private readonly MatchesDbContext _matchesDbContext;

        public CountryRepository(MatchesDbContext matchesDbContext)
        {
            _matchesDbContext = matchesDbContext;
        }

        public IEnumerable<Country> GetAll()
        {
            return _matchesDbContext.Countries.ToList();
        }
    }
}
