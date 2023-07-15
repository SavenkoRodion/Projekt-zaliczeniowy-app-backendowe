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

        public async Task<IEnumerable<TeamDtoResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Team> teamsFromDb = await _matchesDbContext.Teams
                .Include(x => x.League)
                    .ThenInclude(league => league.Country)
                .ToListAsync(cancellationToken);

            IEnumerable<TeamDtoResponse> teamDto = _mapper.Map<IEnumerable<TeamDtoResponse>>(teamsFromDb);

            return teamDto;
        }

        public async Task<TeamDtoResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            IEnumerable<Team> teamsFromDb = await _matchesDbContext.Teams
                .Include(team => team.League)
                    .ThenInclude(league => league.Country)
                .ToListAsync(cancellationToken);

            Team? team = teamsFromDb.Where(team => team.Id == id).FirstOrDefault();

            TeamDtoResponse teamDto = _mapper.Map<TeamDtoResponse>(team);

            return teamDto;
        }

        public async Task AddAsync(IEnumerable<TeamDtoRequest> teams, CancellationToken cancellationToken)
        {
            Team teamsDbModel;
            foreach (TeamDtoRequest team in teams)
            {
                teamsDbModel = _mapper.Map<Team>(team);

                _matchesDbContext.Teams.Attach(teamsDbModel);
                _matchesDbContext.Teams.Entry(teamsDbModel).State = EntityState.Added;
            }
            await _matchesDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Teams.Where(match => match.Id == id).ExecuteDeleteAsync(cancellationToken);
            }
        }

        public async Task UpdateAsync(IEnumerable<TeamDtoRequest> teamsToUpdate, CancellationToken cancellationToken)
        {
            foreach (TeamDtoRequest teamToUpdate in teamsToUpdate)
            {
                Team teamFromDb = await _matchesDbContext.Teams.AsNoTracking().Where(match => match.Id == teamToUpdate.Id).FirstAsync(cancellationToken);

                Team updatedTeam = _mapper.Map<Team>(teamToUpdate);

                teamFromDb = updatedTeam;
                _matchesDbContext.Teams.Entry(teamFromDb).State = EntityState.Modified;
            }
            await _matchesDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
