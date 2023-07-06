﻿using AutoMapper;
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
            IEnumerable<Country> countriesFromDb = _matchesDbContext.Countries.ToList();

            IEnumerable<CountryDto> countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countriesFromDb);

            return countriesDto;
        }

        public async Task<CountryDto?> GetByIdAsync(int id)
        {
            IEnumerable<Country> countriesFromDb = _matchesDbContext.Countries.ToList();

            Country? countryFromDb = countriesFromDb.Where(country => country.Id == id).FirstOrDefault();

            CountryDto countryDto = _mapper.Map<CountryDto>(countryFromDb);

            return countryDto;
        }

        public async Task AddAsync(IEnumerable<CountryDto> countriesDtp)
        {
            Country countryDbModel;
            foreach (CountryDto countryDto in countriesDtp)
            {
                countryDbModel = _mapper.Map<Country>(countryDto);
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
                Country countryFromDb = await _matchesDbContext.Countries.AsNoTracking().Where(match => match.Id == countryToUpdate.Id).FirstAsync();

                Country updatedCountry = _mapper.Map<Country>(countryToUpdate);

                countryFromDb = updatedCountry;
                _matchesDbContext.Countries.Entry(countryFromDb).State = EntityState.Modified;
            }
            await _matchesDbContext.SaveChangesAsync();
        }
    }
}
