using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public ICollection<Game>? games { get; set; }
    }
}
