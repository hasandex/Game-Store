namespace GameZone.Services
{
    public interface ICategoriesService
    {
        public IEnumerable<SelectListItem> GetCategories();
    }
}
