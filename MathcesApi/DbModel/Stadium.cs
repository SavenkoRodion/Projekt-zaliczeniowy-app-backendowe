namespace MathcesApi.DbModel
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<Match> Matches { get; set; }
    }
}
