namespace Wsei.Matches.Infrastructure.Dtos.Responses
{
    public class MatchDtoResponse
    {
        public int Id { get; set; }
        public TeamDtoResponse HomeTeam { get; set; } = null!;
        public TeamDtoResponse GuestTeam { get; set; } = null!;
        public LeagueDtoResponse? League { get; set; }
        public StadiumDto? Stadium { get; set; }
        public DateTime? MatchDate { get; set; }
        public float? TicketPrice { get; set; }
        public float? HomeTeamWinRate { get; set; }
    }
}
