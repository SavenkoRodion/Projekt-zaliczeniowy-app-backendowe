namespace Wsei.Matches.Infrastructure.Dtos.Requests
{
    public class MatchDtoRequest
    {
        public int? Id { get; set; }
        public int? HomeTeamId { get; set; }
        public int? GuestTeamId { get; set; }
        public int? LeagueId { get; set; }
        public int? StadiumId { get; set; }
        public DateTime? MatchDate { get; set; }
        public float? TicketPrice { get; set; }
    }
}
