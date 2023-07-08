using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Application.Dtos.Requests;
using Wsei.Matches.Application.Dtos.Responses;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;
using Match = Wsei.Matches.Core.DbModel.Match;

namespace Wsei.Matches.Infrastructure.Repositories
{
    public class MatchRepository : IRepository<MatchDtoRequest, MatchDtoResponse>
    {
        private readonly MatchesDbContext _matchesDbContext;
        private readonly IMapper _mapper;

        public MatchRepository(MatchesDbContext matchesDbContext, IMapper mapper)
        {
            _matchesDbContext = matchesDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchDtoResponse>> GetAllAsync()
        {
            IEnumerable<Match> allMatchesFromDb = GetAllMatchesFromDb();

            IEnumerable<MatchDtoResponse> matchesDto = _mapper.Map<IEnumerable<MatchDtoResponse>>(allMatchesFromDb);

            return matchesDto;
        }

        public async Task<MatchDtoResponse?> GetByIdAsync(int id)
        {
            IEnumerable<Match> allMatchesFromDb = GetAllMatchesFromDb();

            Match? match = allMatchesFromDb.Where(match => match.Id == id)
                .FirstOrDefault();

            MatchDtoResponse matchDto = _mapper.Map<MatchDtoResponse>(match);

            return matchDto;
        }

        public async Task AddAsync(IEnumerable<MatchDtoRequest> matches)
        {
            Match matchDbModel;
            foreach (MatchDtoRequest match in matches)
            {
                matchDbModel = _mapper.Map<Match>(match);

                _matchesDbContext.Matches.Attach(matchDbModel);
                _matchesDbContext.Matches.Entry(matchDbModel).State = EntityState.Added;
            }
            await _matchesDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Matches.Where(match => match.Id == id).ExecuteDeleteAsync();
            }
        }

        public async Task UpdateAsync(IEnumerable<MatchDtoRequest> matchesToUpdate)
        {
            foreach (MatchDtoRequest matchToUpdate in matchesToUpdate)
            {
                Match matchFromDb = await _matchesDbContext.Matches.AsNoTracking().Where(match => match.Id == matchToUpdate.Id).FirstAsync();

                Match updatedMatch = _mapper.Map<Match>(matchToUpdate);

                matchFromDb = updatedMatch;
                _matchesDbContext.Matches.Entry(matchFromDb).State = EntityState.Modified;
            }
            await _matchesDbContext.SaveChangesAsync();
        }

        private IEnumerable<Match> GetAllMatchesFromDb()
        {
            return _matchesDbContext.Matches
                .Include(match => match.HomeTeam)
                    .ThenInclude(homeTeam => homeTeam.League)
                        .ThenInclude(league => league.Country)

                .Include(match => match.GuestTeam)
                    .ThenInclude(guestTeam => guestTeam.League)
                        .ThenInclude(league => league.Country)

                .Include(match => match.League)
                    .ThenInclude(league => league.Country)

                .Include(match => match.Stadium).ToList();
        }
    }
}
