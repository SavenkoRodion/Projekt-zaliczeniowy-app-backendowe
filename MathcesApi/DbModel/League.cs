namespace MathcesApi.DbModel
{
    public class League
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public Country Country { get; init; }
        public IEnumerable<League> Legue { get; init; }
    }
}
