namespace Wsei.Matches.Core.DbModel
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Country? Country { get; set; }
        public IEnumerable<Team>? Teams { get; set; }
        public IEnumerable<Match>? Matches { get; set; }
    }
}
