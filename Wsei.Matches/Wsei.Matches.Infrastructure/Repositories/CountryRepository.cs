using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            IEnumerable<Country> countriesDbModel = _matchesDbContext.Countries.ToList();

            IEnumerable<CountryDto> countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countriesDbModel);

            return countriesDto;
        }

        public async Task<CountryDto?> GetByIdAsync(int id)
        {
            IEnumerable<Country> countriesDbModel = _matchesDbContext.Countries.ToList();

            Country? country = countriesDbModel.Where(country => country.Id == id).FirstOrDefault();

            CountryDto countryDto = _mapper.Map<CountryDto>(country);

            return countryDto;
        }

        public async Task AddAsync(IEnumerable<CountryDto> countries)
        {
            Country countryDbModel;
            foreach (CountryDto country in countries)
            {
                countryDbModel = _mapper.Map<Country>(country);
                await _matchesDbContext.Countries.AddAsync(countryDbModel);
            }
            await _matchesDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Countries.Where(country => country.Id == id).ExecuteDeleteAsync();
            }
        }

        public async Task UpdateAsync(IEnumerable<CountryDto> countriesToUpdate)
        {
            foreach (CountryDto countryToUpdate in countriesToUpdate)
            {
                Country mappedCountryToUpdate = _mapper.Map<Country>(countryToUpdate);
                var countryFromDb = await _matchesDbContext.Countries.Where(country => country.Id == countryToUpdate.Id).FirstOrDefaultAsync();
                countryFromDb.Name = mappedCountryToUpdate.Name;
            }
            await _matchesDbContext.SaveChangesAsync();
        }
    }
}
