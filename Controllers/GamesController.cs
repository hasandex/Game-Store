using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GameZone.Controllers
{
    //[Authorize(Roles = ClsRoles.roleUser)]
    public class GamesController : Controller
    {
        public GamesController(AppDbContext context,
            ICategoriesService categories,
            IDevicesService devicesService,
            IGamesService gamesService)
        {
            _context = context;
            _categoriesService = categories;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }
        private readonly IGamesService _gamesService;
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly AppDbContext _context;
        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var game = _gamesService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Select_Categories = _categoriesService.GetCategories(),
                Select_Devices = _devicesService.GetDevices(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel mdl)
        {
            CreateGameFormViewModel viewModel = new()
            {
                Select_Categories = _categoriesService.GetCategories(),
                Select_Devices = _devicesService.GetDevices(),
            };

            if (!ModelState.IsValid)
            {
                mdl.Select_Categories = _categoriesService.GetCategories();
                mdl.Select_Devices = _devicesService.GetDevices();
                return View(viewModel);
            }
            await _gamesService.Create(mdl);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gamesService.GetById(id);

            if (game is null)
                return NotFound();

            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                categoryId = game.categoryId,
                SelectedDevices = game.gameDevices.Select(d => d.deviceId).ToList(),
                Select_Categories = _categoriesService.GetCategories(),
                Select_Devices = _devicesService.GetDevices(),
                CurrentCover = game.Cover
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                model.Select_Categories = _categoriesService.GetCategories();
                model.Select_Devices = _devicesService.GetDevices();
                TempData["Error"] = "Oops!!";
                return View(model);
            }

            var game = await _gamesService.Update(model);
            TempData["Success"] = "your game has been edited";
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gamesService.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
       
    }
}
