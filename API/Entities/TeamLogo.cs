using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("TeamLogos")]
    public class TeamLogo
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? PublicId { get; set; }
        public Team? Team { get; set; }
        public int TeamId { get; set; }
    }
}