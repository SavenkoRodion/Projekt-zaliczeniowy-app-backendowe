namespace MathcesApi.DbModel
{
    public class Team
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public League League { get; init; }
        public Country Country { get; init; }
        public IEnumerable<Match> Match { get; init; }
    }
}
