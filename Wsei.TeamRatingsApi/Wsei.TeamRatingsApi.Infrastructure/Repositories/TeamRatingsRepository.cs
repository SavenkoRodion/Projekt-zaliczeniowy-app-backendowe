using Microsoft.EntityFrameworkCore;
using Wsei.TeamRatingsApi.Core.DbModel;
using Wsei.TeamRatingsApi.Core.Interfaces;
using Wsei.TeamRatingsApi.Infrastructure.Dtos;

namespace Wsei.TeamRatingsApi.Infrastructure.Repositories
{
    public class TeamRatingsRepository : ITeamRatingRepository<TeamRatingDto, TeamRatingDto>
    {
        private readonly TeamRatingsDbContext _teamRatingsDbContext;

        public TeamRatingsRepository(TeamRatingsDbContext teamRatingsDbContext)
        {
            _teamRatingsDbContext = teamRatingsDbContext;
        }

        public async Task<IEnumerable<TeamRatingDto>> GetAllAsync()
        {
            IEnumerable<TeamRating> ratedTeamsFromDb = _teamRatingsDbContext.RatedTeams.ToList();

            IEnumerable<TeamRatingDto> ratedTeamsDto = CustomMapper.Map(ratedTeamsFromDb);

            return ratedTeamsDto;
        }

        public async Task<TeamRatingDto?> GetByIdAsync(int id)
        {
            IEnumerable<TeamRating> ratedTeamsFromDb = _teamRatingsDbContext.RatedTeams.ToList();

            TeamRating? ratedTeamFromDb = ratedTeamsFromDb.Where(team => team.Id == id).First();

            TeamRatingDto ratedTeamDto = CustomMapper.Map(ratedTeamFromDb);

            return ratedTeamDto;
        }

        public async Task<TeamRatingDto?> GetByNameAsync(string teamName)
        {
            IEnumerable<TeamRating> ratedTeamsFromDb = _teamRatingsDbContext.RatedTeams.ToList();

            TeamRating? ratedTeamFromDb = ratedTeamsFromDb.Where(team => team.Name == teamName).FirstOrDefault();

            if (ratedTeamFromDb is not null)
            {
                return CustomMapper.Map(ratedTeamFromDb);
            }
            else
            {
                return null;
            }
        }

        public async Task AddAsync(IEnumerable<TeamRatingDto> ratedTeamsDto)
        {
            TeamRating ratedTeamDbModel;
            foreach (TeamRatingDto ratedTeamDto in ratedTeamsDto)
            {
                ratedTeamDbModel = CustomMapper.Map(ratedTeamDto);
                await _teamRatingsDbContext.RatedTeams.AddAsync(ratedTeamDbModel);
            }
            await _teamRatingsDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                await _teamRatingsDbContext.RatedTeams.Where(team => team.Id == id).ExecuteDeleteAsync();
            }
        }

        public async Task ReplaceAsync(IEnumerable<TeamRatingDto> ratedTeamsToUpdate)
        {
            foreach (TeamRatingDto ratedTeamToUpdate in ratedTeamsToUpdate)
            {
                TeamRating ratedTeamFromDb = await _teamRatingsDbContext.RatedTeams.AsNoTracking().Where(match => match.Id == ratedTeamToUpdate.Id).FirstAsync();

                TeamRating updatedTeam = CustomMapper.Map(ratedTeamToUpdate);

                ratedTeamFromDb = updatedTeam;
                _teamRatingsDbContext.RatedTeams.Entry(ratedTeamFromDb).State = EntityState.Modified;
            }
            await _teamRatingsDbContext.SaveChangesAsync();
        }
    }
}
