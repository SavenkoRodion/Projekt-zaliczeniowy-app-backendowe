namespace Wsei.Matches.Infrastructure.Services;
public interface IMatchService
{
    public Task<float> SetWinrateChanseAsync(string homeTeamName, string guestTeamName);
}
