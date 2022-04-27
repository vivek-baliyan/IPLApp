using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int MatchNo { get; set; }
        public DateTime MatchDate { get; set; }
        public string? Venue { get; set; }
        public ICollection<MatchDetailsDto>? MatchDetails { get; set; }
    }
}