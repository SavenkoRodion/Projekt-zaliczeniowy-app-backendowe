using System.Net;
using System.Net.Http.Json;
using Wsei.Matches.Infrastructure.Dtos;

namespace Wsei.Matches.Infrastructure.Services;

public class MatchService : IMatchService
{
    public async Task<float?> GetHomeTeamWinrateChanseAsync(string homeTeamName, string guestTeamName)
    {
        HttpClient client = HttpClientUtil.GetHttpClient();
        HttpResponseMessage homeTeamRatingResponse = await client.GetAsync($"/teamRating/byTeamName/{homeTeamName}");
        if (homeTeamRatingResponse.Content is null || homeTeamRatingResponse.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
        var homeTeamRating = await homeTeamRatingResponse.Content.ReadFromJsonAsync<TeamRatingDto?>();

        HttpResponseMessage guestTeamRatingResponse = await client.GetAsync($"/teamRating/byTeamName/{guestTeamName}");
        if (guestTeamRatingResponse.Content is null || guestTeamRatingResponse.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
        var guestTeamRating = await guestTeamRatingResponse.Content.ReadFromJsonAsync<TeamRatingDto?>();

        var homeTeamWinRate = GetHomeTeamWinRate(homeTeamRating!, guestTeamRating!);

        return homeTeamWinRate;
    }

    private static float GetHomeTeamWinRate(TeamRatingDto homeTeamRating, TeamRatingDto guestTeamRating)
    {
        if (homeTeamRating.Rating < guestTeamRating.Rating)
        {
            return (float)(((float)homeTeamRating.Rating / (float)guestTeamRating.Rating) * 0.5);
        }
        else if (homeTeamRating.Rating > guestTeamRating.Rating)
        {
            return (float)(1 - ((float)homeTeamRating.Rating / (float)guestTeamRating.Rating) * 0.5);
        }
        else
        {
            return 0.5F;
        }
    }
}
