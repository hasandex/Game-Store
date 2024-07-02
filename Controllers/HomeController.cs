using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList.Mvc;
namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGamesService _gamesService;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, IGamesService gamesService, AppDbContext appDbContext)
        {
            _logger = logger;
            _gamesService = gamesService;
            _appDbContext = appDbContext;
        }

        public IActionResult Index(string? seachName, string? categoryName, int pg = 1)
        {
            var games = _gamesService.GetAll();
            if (!string.IsNullOrEmpty(seachName))
            {
                games = games.Where(g => g.Name.ToLower().Contains(seachName.ToLower())
                    || g.Description.ToLower().Contains(seachName.ToLower())).ToList();
            }
            else if (categoryName != null)
            {
                games = games.Where(g => g.category.Name.ToLower() == categoryName.ToLower()).ToList();
            }
            ViewBag.seachName = seachName;
            ViewBag.categories = _appDbContext.categories.ToList();
            //Pagenatio
            const int pageSize = 6;
            if (pg < 1) { pg = 1; }
            int rescCount = games.Count();
            var pager = new Pager(rescCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = games.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);
        }

        //public IActionResult Privacy()Ó
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult CountriesAndCities()
        {
            var list = new SelectList(_appDbContext.countries.ToList(),"Id","Name");
            
            var countryModel = new CountryAndCityForm()
            {
                Country = list,
               
            };
            return View(countryModel);        
        }
        public IActionResult GetCities(int countryId)
        {
            var cities = _appDbContext.cities.Where(c => c.CountryId == countryId).ToList();
            return Ok(cities);
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
