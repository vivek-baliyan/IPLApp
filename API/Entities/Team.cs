using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Teams")]
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string? TeamName { get; set; }
        public string? ShortName { get; set; }
        public string? Owner { get; set; }
        public string? Venue { get; set; }
        public string? Coach { get; set; }
        public string? Captain { get; set; }
        public int Year { get; set; }
        public TeamLogo? Logo { get; set; }
    }
}