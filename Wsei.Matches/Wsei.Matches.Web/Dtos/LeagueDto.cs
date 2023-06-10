namespace Wsei.Matches.Web.Dtos
{
    public class LeagueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDto? Country { get; set; }
        public IEnumerable<TeamDto> Teams { get; set; }
        public IEnumerable<MatchDto> Matches { get; set; }
    }
}
