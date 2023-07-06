using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;

namespace Wsei.Matches.Infrastructure.Repositories
{
    public class LeagueRepository : IRepository<LeagueDto>
    {
        private readonly MatchesDbContext _matchesDbContext;
        private readonly IMapper _mapper;

        public LeagueRepository(MatchesDbContext matchesDbContext, IMapper mapper)
        {
            _matchesDbContext = matchesDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeagueDto>> GetAllAsync()
        {
            IEnumerable<League> leaguesDbModel = _matchesDbContext.Leagues.ToList();

            IEnumerable<LeagueDto> leaguesDto = _mapper.Map<IEnumerable<LeagueDto>>(leaguesDbModel);

            return leaguesDto;
        }

        public async Task<LeagueDto?> GetByIdAsync(int id)
        {
            IEnumerable<League> leaguesDbModel = _matchesDbContext.Leagues.ToList();

            League? league = leaguesDbModel.Where(match => match.Id == id).FirstOrDefault();

            LeagueDto leagueDto = _mapper.Map<LeagueDto>(league);

            return leagueDto;
        }

        public async Task AddAsync(IEnumerable<LeagueDto> leagues)
        {
            League leaguesDbModel;
            foreach (LeagueDto league in leagues)
            {
                leaguesDbModel = _mapper.Map<League>(league);
                await _matchesDbContext.Leagues.AddAsync(leaguesDbModel);
            }
            await _matchesDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Leagues.Where(match => match.Id == id).ExecuteDeleteAsync();
            }
        }

        public async Task UpdateAsync(IEnumerable<LeagueDto> leaguesToUpdate)
        {
            foreach (LeagueDto leagueToUpdate in leaguesToUpdate)
            {
                var leagueFromDb = await _matchesDbContext.Leagues.AsNoTracking().Where(match => match.Id == leagueToUpdate.Id).FirstOrDefaultAsync();
                League mappedLeagueToUpdate = _mapper.Map<League>(leagueToUpdate);
                leagueFromDb = mappedLeagueToUpdate;
                _matchesDbContext.Leagues.Entry(leagueFromDb).State = EntityState.Modified;
            }
            await _matchesDbContext.SaveChangesAsync();
        }
    }
}
