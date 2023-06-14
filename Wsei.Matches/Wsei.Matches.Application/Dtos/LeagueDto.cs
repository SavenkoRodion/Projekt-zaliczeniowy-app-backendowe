namespace Wsei.Matches.Application.Dtos
{
    public class LeagueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDto? Country { get; set; }
    }
}
