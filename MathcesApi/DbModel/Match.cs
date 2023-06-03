using System.ComponentModel.DataAnnotations.Schema;

namespace MathcesApi.DbModel
{
    public class Match
    {
        public int Id { get; init; }
        [InverseProperty(" create property for Team on HomeTeam")]
        public Team HomeTeam { get; set; }
        [InverseProperty(" create property for Team on GuestTeam")]
        public Team GuestTeam { get; set; }
        public Stadium? Stadium { get; init; }
        public DateTime? MatchDate { get; init; }
        public float? TicketPrice { get; init; } 
    }
}
