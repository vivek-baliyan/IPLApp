using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Players")]
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}