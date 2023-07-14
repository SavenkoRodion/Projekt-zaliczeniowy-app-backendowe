namespace Wsei.Matches.Infrastructure.Services;
public interface IMatchService
{
    public Task<float?> GetHomeTeamWinrateChanseAsync(string homeTeamName, string guestTeamName);
}
