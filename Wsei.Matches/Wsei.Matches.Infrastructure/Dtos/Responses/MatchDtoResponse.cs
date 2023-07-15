namespace Wsei.Matches.Infrastructure.Dtos.Responses
{
    public record MatchDtoResponse(
        int Id,
        TeamDtoResponse HomeTeam,
        TeamDtoResponse GuestTeam,
        LeagueDtoResponse? League,
        StadiumDto? Stadium,
        DateTime? MatchDate,
        float? TicketPrice,
        float? HomeTeamWinRate);
}
