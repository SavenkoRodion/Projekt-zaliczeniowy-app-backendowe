using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;
using Wsei.Matches.Infrastructure.Dtos;

namespace Wsei.Matches.Infrastructure.Repositories
{
    public class StadiumRepository : IRepository<StadiumDto, StadiumDto>
    {
        private readonly MatchesDbContext _matchesDbContext;
        private readonly IMapper _mapper;

        public StadiumRepository(MatchesDbContext matchesDbContext, IMapper mapper)
        {
            _matchesDbContext = matchesDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StadiumDto>> GetAllAsync()
        {
            IEnumerable<Stadium> stadiumsFromDb = await _matchesDbContext.Stadiums.ToListAsync();

            IEnumerable<StadiumDto> stadiumDto = _mapper.Map<IEnumerable<StadiumDto>>(stadiumsFromDb);

            return stadiumDto;
        }

        public async Task<StadiumDto?> GetByIdAsync(int id)
        {
            Stadium? stadium = await _matchesDbContext.Stadiums.Where(stadium => stadium.Id == id).FirstOrDefaultAsync();

            if (stadium is not null)
            {
                return _mapper.Map<StadiumDto>(stadium);
            }
            else
            {
                return null;
            }
        }

        public async Task AddAsync(IEnumerable<StadiumDto> stadiums)
        {
            Stadium stadiumDbModel;
            foreach (StadiumDto stadium in stadiums)
            {
                stadiumDbModel = _mapper.Map<Stadium>(stadium);
                await _matchesDbContext.Stadiums.AddAsync(stadiumDbModel);
            }
            await _matchesDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Stadiums.Where(match => match.Id == id).ExecuteDeleteAsync();
            }
        }

        public async Task UpdateAsync(IEnumerable<StadiumDto> stadiumsToUpdate)
        {
            foreach (StadiumDto stadiumToUpdate in stadiumsToUpdate)
            {
                Stadium stadiumFromDb = await _matchesDbContext.Stadiums.AsNoTracking().Where(match => match.Id == stadiumToUpdate.Id).FirstAsync();

                Stadium updatedStadium = _mapper.Map<Stadium>(stadiumToUpdate);

                stadiumFromDb = updatedStadium;
                _matchesDbContext.Stadiums.Entry(stadiumFromDb).State = EntityState.Modified;
            }
            await _matchesDbContext.SaveChangesAsync();
        }
    }
}
