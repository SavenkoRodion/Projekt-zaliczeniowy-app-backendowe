namespace MathcesApi.DbModel
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public League? League { get; set; }
        public IEnumerable<Match> HomeMatches { get; set; }
        public IEnumerable<Match> GuestMatches { get; set; }
    }
}
