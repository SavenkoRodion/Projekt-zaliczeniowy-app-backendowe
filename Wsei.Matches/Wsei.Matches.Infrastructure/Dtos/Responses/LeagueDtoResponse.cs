namespace Wsei.Matches.Infrastructure.Dtos.Responses
{
    public class LeagueDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDto? Country { get; set; }
    }
}
