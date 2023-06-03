namespace MathcesApi.DbModel
{
    public class Stadium
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Address { get; init; }
        public IEnumerable<Match> Match { get; init; }
    }
}
