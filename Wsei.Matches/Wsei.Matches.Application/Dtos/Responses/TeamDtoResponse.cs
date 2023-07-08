namespace Wsei.Matches.Application.Dtos.Responses
{
    public class TeamDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LeagueDtoResponse? League { get; set; }
    }
}
