namespace Wsei.Matches.Application.Dtos
{
    public class MatchDto
    {
        public int? Id { get; set; }
        public TeamDto? HomeTeam { get; set; }
        public TeamDto? GuestTeam { get; set; }
        public LeagueDto? League { get; set; }
        public StadiumDto? Stadium { get; set; }
        public DateTime? MatchDate { get; set; }
        public float? TicketPrice { get; set; }
    }
}
