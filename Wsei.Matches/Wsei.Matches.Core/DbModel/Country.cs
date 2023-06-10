namespace Wsei.Matches.Core.DbModel
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<League> Leagues { get; set; }
    }
}
