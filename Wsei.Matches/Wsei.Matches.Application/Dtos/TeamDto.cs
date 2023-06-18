namespace Wsei.Matches.Application.Dtos
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LeagueDto? League { get; set; }
    }
}
