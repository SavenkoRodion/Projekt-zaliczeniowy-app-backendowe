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

        public async Task<IEnumerable<StadiumDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Stadium> stadiumsFromDb = await _matchesDbContext.Stadiums.ToListAsync(cancellationToken);

            IEnumerable<StadiumDto> stadiumDto = _mapper.Map<IEnumerable<StadiumDto>>(stadiumsFromDb);

            return stadiumDto;
        }

        public async Task<StadiumDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            IEnumerable<Stadium> stadiumsFromDb = await _matchesDbContext.Stadiums.ToListAsync(cancellationToken);

            Stadium? stadium = stadiumsFromDb.Where(stadium => stadium.Id == id).FirstOrDefault();

            StadiumDto stadiumDto = _mapper.Map<StadiumDto>(stadium);

            return stadiumDto;
        }

        public async Task AddAsync(IEnumerable<StadiumDto> stadiums, CancellationToken cancellationToken)
        {
            Stadium stadiumDbModel;
            foreach (StadiumDto stadium in stadiums)
            {
                stadiumDbModel = _mapper.Map<Stadium>(stadium);
                await _matchesDbContext.Stadiums.AddAsync(stadiumDbModel, cancellationToken);
            }
            await _matchesDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Stadiums.Where(match => match.Id == id).ExecuteDeleteAsync(cancellationToken);
            }
        }

        public async Task UpdateAsync(IEnumerable<StadiumDto> stadiumsToUpdate, CancellationToken cancellationToken)
        {
            foreach (StadiumDto stadiumToUpdate in stadiumsToUpdate)
            {
                Stadium stadiumFromDb = await _matchesDbContext.Stadiums.AsNoTracking().Where(match => match.Id == stadiumToUpdate.Id).FirstAsync(cancellationToken);

                Stadium updatedStadium = _mapper.Map<Stadium>(stadiumToUpdate);

                stadiumFromDb = updatedStadium;
                _matchesDbContext.Stadiums.Entry(stadiumFromDb).State = EntityState.Modified;
            }
            await _matchesDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
