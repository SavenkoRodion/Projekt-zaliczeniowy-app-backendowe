using System.ComponentModel.DataAnnotations.Schema;

namespace MathcesApi.DbModel
{
    public class Match
    {
        public int Id { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? GuestTeam { get; set; }
        public League? League { get; set; }
        public Stadium? Stadium { get; set; }
        public DateTime? MatchDate { get; set; }
        public float? TicketPrice { get; set; } 
    }
}
