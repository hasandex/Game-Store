using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModel
{
    public class GameForm
    {
        public string Name { get; set; } = string.Empty;

        [Required]

        [Display(Name = "Category")]
        public int categoryId { get; set; }
        public IEnumerable<SelectListItem> Select_Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Required]
        [Display(Name = "Supported Device")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Select_Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        //public int CountryId {  get; set; }
        //public IEnumerable<SelectListItem> CountryName { get; set; } = Enumerable.Empty<SelectListItem>();
        //public int CityId {  get; set; }
        //public IEnumerable<SelectListItem> CityName { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
