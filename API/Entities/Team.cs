using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Teams")]
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Logo { get; set; }
    }
}