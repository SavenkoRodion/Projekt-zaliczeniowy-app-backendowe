namespace Wsei.Matches.Application.Dtos.Responses
{
    public class MatchDtoResponse
    {
        public int? Id { get; set; }
        public TeamDtoResponse? HomeTeam { get; set; }
        public TeamDtoResponse? GuestTeam { get; set; }
        public LeagueDtoResponse? League { get; set; }
        public StadiumDto? Stadium { get; set; }
        public DateTime? MatchDate { get; set; }
        public float? TicketPrice { get; set; }
    }
}
