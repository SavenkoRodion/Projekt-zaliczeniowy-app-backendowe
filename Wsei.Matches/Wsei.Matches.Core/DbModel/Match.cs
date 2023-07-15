namespace Wsei.Matches.Core.DbModel
{
    public class Match
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; } = null!;
        public Team GuestTeam { get; set; } = null!;
        public League? League { get; set; }
        public Stadium? Stadium { get; set; }
        public DateTime? MatchDate { get; set; }
        public float? TicketPrice { get; set; }
    }
}
