using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;

namespace Wsei.Matches.Infrastructure.Repositories
{
    public class TeamRepository : IRepository<TeamDto>
    {
        private readonly MatchesDbContext _matchesDbContext;
        private readonly IMapper _mapper;

        public TeamRepository(MatchesDbContext matchesDbContext, IMapper mapper)
        {
            _matchesDbContext = matchesDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            IEnumerable<Team> teamsFromDb = _matchesDbContext.Teams.ToList();

            IEnumerable<TeamDto> teamDto = _mapper.Map<IEnumerable<TeamDto>>(teamsFromDb);

            return teamDto;
        }

        public async Task<TeamDto?> GetByIdAsync(int id)
        {
            IEnumerable<Team> teamsFromDb = _matchesDbContext.Teams.ToList();

            Team? team = teamsFromDb.Where(match => match.Id == id).FirstOrDefault();

            TeamDto teamDto = _mapper.Map<TeamDto>(team);

            return teamDto;
        }

        public async Task AddAsync(IEnumerable<TeamDto> teams)
        {
            Team teamsDbModel;
            foreach (TeamDto team in teams)
            {
                teamsDbModel = _mapper.Map<Team>(team);
                await _matchesDbContext.Teams.AddAsync(teamsDbModel);
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

        public async Task UpdateAsync(IEnumerable<TeamDto> teamsToUpdate)
        {
            foreach (TeamDto teamToUpdate in teamsToUpdate)
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
