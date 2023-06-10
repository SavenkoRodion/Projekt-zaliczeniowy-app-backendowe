namespace Wsei.Matches.Web.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LeagueDto> Leagues { get; set; }
    }
}
