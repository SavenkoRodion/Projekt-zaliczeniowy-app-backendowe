using Wsei.TeamRatingsApi.Core.DbModel;
using Wsei.TeamRatingsApi.Infrastructure.Dtos;

namespace Wsei.TeamRatingsApi.Infrastructure;
public static class CustomMapper
{
    public static TeamRatingDto Map(TeamRating ratedTeam)
    {
        return new TeamRatingDto(ratedTeam.Id, ratedTeam.Name, ratedTeam.Rating);
    }

    public static IEnumerable<TeamRatingDto> Map(IEnumerable<TeamRating> ratedTeams)
    {
        List<TeamRatingDto> mappedRatedTeams = new List<TeamRatingDto>();
        foreach (var ratedTeam in ratedTeams)
        {
            mappedRatedTeams.Add(new TeamRatingDto(ratedTeam.Id, ratedTeam.Name, ratedTeam.Rating));
        }

        return mappedRatedTeams;
    }

    public static TeamRating Map(TeamRatingDto ratedTeam)
    {
        return new TeamRating { Id = ratedTeam.Id, Name = ratedTeam.Name, Rating = ratedTeam.Rating };
    }

    public static IEnumerable<TeamRating> Map(IEnumerable<TeamRatingDto> ratedTeams)
    {
        List<TeamRating> mappedRatedTeams = new List<TeamRating>();
        foreach (var ratedTeam in ratedTeams)
        {
            mappedRatedTeams.Add(new TeamRating { Id = ratedTeam.Id, Name = ratedTeam.Name, Rating = ratedTeam.Rating });
        }

        return mappedRatedTeams;
    }
}
