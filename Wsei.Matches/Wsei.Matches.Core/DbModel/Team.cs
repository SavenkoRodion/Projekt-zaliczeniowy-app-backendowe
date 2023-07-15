namespace Wsei.Matches.Core.DbModel
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public League? League { get; set; }
        public IEnumerable<Match>? HomeMatches { get; set; }
        public IEnumerable<Match>? GuestMatches { get; set; }
    }
}
