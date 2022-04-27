using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Matches")]
    public class Match
    {
        public int Id { get; set; }
        public int MatchNo { get; set; }
        public DateTime MatchDate { get; set; }
        public string? Venue { get; set; }
        public ICollection<MatchDetails>? MatchDetails { get; set; }
    }
}