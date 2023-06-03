namespace MathcesApi.DbModel
{
    public class Country
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public IEnumerable<League> League { get; init; }
    }
}
