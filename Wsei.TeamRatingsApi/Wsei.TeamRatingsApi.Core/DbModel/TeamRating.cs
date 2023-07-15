namespace Wsei.TeamRatingsApi.Core.DbModel
{
    public record TeamRating()
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Rating { get; set; }
    }
}
