using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
      
        public string Cover { get; set; } = string.Empty;
        [ForeignKey("category")]
        public int categoryId { get; set; }
        public Category? category { get; set; }
        public ICollection<GameDevice>? gameDevices { get; set; }
    }
}
