namespace Wsei.Matches.Core.DbModel
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public IEnumerable<Match>? Matches { get; set; }
    }
}
