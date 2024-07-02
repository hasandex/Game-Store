using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        public ICollection<GameDevice>? devices { get; set; }
    }
}
