using AutoMapper;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;

namespace Wsei.Matches.Infrastructure.Repositories
{
    public class CountryRepository : IRepository<CountryDto>
    {
        private readonly MatchesDbContext _matchesDbContext;
        private readonly IMapper _mapper;

        public CountryRepository(MatchesDbContext matchesDbContext, IMapper mapper)
        {
            _matchesDbContext = matchesDbContext;
            _mapper = mapper;
        }

        public IEnumerable<CountryDto> GetAll()
        {
            IEnumerable<Country> lol = _matchesDbContext.Countries.ToList();

            IEnumerable<CountryDto> lolDto = _mapper.Map<IEnumerable<CountryDto>>(lol);

            return lolDto;
        }
    }
}
