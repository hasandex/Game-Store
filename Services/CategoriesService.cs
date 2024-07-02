
namespace GameZone.Services
{
    public class CategoriesService : ICategoriesService
    {
        public CategoriesService(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
        public IEnumerable<SelectListItem> GetCategories()
        {
            return _context.categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text).AsNoTracking().ToList();
        }
    }
}
