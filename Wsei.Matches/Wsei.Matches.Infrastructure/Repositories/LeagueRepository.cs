using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;

namespace Wsei.Matches.Infrastructure.Repositories
{
    public class LeagueRepository : IRepository<LeagueDtoRequest, LeagueDtoResponse>
    {
        private readonly MatchesDbContext _matchesDbContext;
        private readonly IMapper _mapper;

        public LeagueRepository(MatchesDbContext matchesDbContext, IMapper mapper)
        {
            _matchesDbContext = matchesDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeagueDtoResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            IEnumerable<League> leaguesFromDb = await _matchesDbContext.Leagues.Include(league => league.Country).ToListAsync(cancellationToken);

            IEnumerable<LeagueDtoResponse> leaguesDto = _mapper.Map<IEnumerable<LeagueDtoResponse>>(leaguesFromDb);

            return leaguesDto;
        }

        public async Task<LeagueDtoResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            IEnumerable<League> leaguesFromDb = await _matchesDbContext.Leagues
                .Include(league => league.Country)
                .ToListAsync(cancellationToken);

            League? league = leaguesFromDb.Where(league => league.Id == id).FirstOrDefault();

            LeagueDtoResponse leagueDto = _mapper.Map<LeagueDtoResponse>(league);

            return leagueDto;
        }

        public async Task AddAsync(IEnumerable<LeagueDtoRequest> leagues, CancellationToken cancellationToken)
        {
            League leaguesDbModel;
            foreach (LeagueDtoRequest league in leagues)
            {
                leaguesDbModel = _mapper.Map<League>(league);

                _matchesDbContext.Leagues.Attach(leaguesDbModel);
                _matchesDbContext.Leagues.Entry(leaguesDbModel).State = EntityState.Added;
            }
            await _matchesDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Leagues.Where(match => match.Id == id).ExecuteDeleteAsync(cancellationToken);
            }
        }

        public async Task UpdateAsync(IEnumerable<LeagueDtoRequest> leaguesToUpdate, CancellationToken cancellationToken)
        {
            foreach (LeagueDtoRequest leagueToUpdate in leaguesToUpdate)
            {
                League leagueFromDb = await _matchesDbContext.Leagues.AsNoTracking().Where(match => match.Id == leagueToUpdate.Id).FirstAsync(cancellationToken);

                League updatedLeague = _mapper.Map<League>(leagueToUpdate);

                leagueFromDb = updatedLeague;
                _matchesDbContext.Leagues.Entry(leagueFromDb).State = EntityState.Modified;
            }
            await _matchesDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
