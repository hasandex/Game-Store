using GameZone.Models;

namespace GameZone.ViewModel
{
    public class CountryAndCityForm
    {
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Country { get; set; } = Enumerable.Empty<SelectListItem>();
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> City { get; set; } = Enumerable.Empty<SelectListItem>();
        
    }
}
