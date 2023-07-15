using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;

namespace Wsei.Matches.Infrastructure.Repositories
{
    public class TeamRepository : IRepository<TeamDtoRequest, TeamDtoResponse>
    {
        private readonly MatchesDbContext _matchesDbContext;
        private readonly IMapper _mapper;

        public TeamRepository(MatchesDbContext matchesDbContext, IMapper mapper)
        {
            _matchesDbContext = matchesDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDtoResponse>> GetAllAsync()
        {
            IEnumerable<Team> teamsFromDb = await _matchesDbContext.Teams
                .Include(x => x.League)
                    .ThenInclude(league => league.Country)
                .ToListAsync();

            IEnumerable<TeamDtoResponse> teamDto = _mapper.Map<IEnumerable<TeamDtoResponse>>(teamsFromDb);

            return teamDto;
        }

        public async Task<TeamDtoResponse?> GetByIdAsync(int id)
        {
            Team? team = await _matchesDbContext.Teams
                .Include(team => team.League)
                    .ThenInclude(league => league.Country)
                .Where(team => team.Id == id)
                .FirstOrDefaultAsync();

            if (team is not null)
            {
                return _mapper.Map<TeamDtoResponse>(team);
            }
            else
            {
                return null;
            }
        }

        public async Task AddAsync(IEnumerable<TeamDtoRequest> teams)
        {
            Team teamsDbModel;
            foreach (TeamDtoRequest team in teams)
            {
                teamsDbModel = _mapper.Map<Team>(team);

                _matchesDbContext.Teams.Attach(teamsDbModel);
                _matchesDbContext.Teams.Entry(teamsDbModel).State = EntityState.Added;
            }
            await _matchesDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Teams.Where(match => match.Id == id).ExecuteDeleteAsync();
            }
        }

        public async Task UpdateAsync(IEnumerable<TeamDtoRequest> teamsToUpdate)
        {
            foreach (TeamDtoRequest teamToUpdate in teamsToUpdate)
            {
                Team teamFromDb = await _matchesDbContext.Teams.AsNoTracking().Where(match => match.Id == teamToUpdate.Id).FirstAsync();

                Team updatedTeam = _mapper.Map<Team>(teamToUpdate);

                teamFromDb = updatedTeam;
                _matchesDbContext.Teams.Entry(teamFromDb).State = EntityState.Modified;
            }
            await _matchesDbContext.SaveChangesAsync();
        }
    }
}
