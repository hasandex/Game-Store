using GameZone.Models;
using GameZone.ViewModel;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace GameZone.Services
{
    public class GamesService : IGamesService
    {
        public GamesService(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            imagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";

        }
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;
        private readonly string imagePath;

        public IEnumerable<Game> GetAll()
        {
          return _context.games.Include(g=>g.category)
                .Include(g=>g.gameDevices)
                .ThenInclude(g=>g.device)
                .AsNoTracking()
                .ToList();
        }
        public async Task Create(CreateGameFormViewModel mdl)
        {
            var coveName = await SaveCover(mdl.Cover);

            //save in database
            Game game = new Game()
            {
                Name = mdl.Name,
                Description = mdl.Description,
                categoryId = mdl.categoryId,
                Cover = coveName,
                gameDevices = mdl.SelectedDevices.Select(sd => new GameDevice { deviceId = sd }).ToList(),
            };
            _context.games.Add(game);
            _context.SaveChanges();
        }

        public Game? GetById(int id)
        {
           return _context.games.Include(g => g.category)
                 .Include(g => g.gameDevices)
                 .ThenInclude(g => g.device)
                 .AsNoTracking()
                 .FirstOrDefault(g => g.Id == id);
        }

        public async Task<Game?> Update(EditGameFormViewModel model)
        {
            var game = _context.games
           .Include(g => g.gameDevices)
           .SingleOrDefault(g => g.Id == model.Id);

            if (game is null)
                return null;

            var hasNewCover = model.Cover is not null;
            var oldCover = game.Cover;
            game.Name = model.Name;
            game.Description = model.Description;
            game.categoryId = model.categoryId;
            game.gameDevices = model.SelectedDevices.Select(d => new GameDevice { deviceId = d }).ToList();

            if (hasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(imagePath, oldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else if (effectedRows == 0 && hasNewCover == false)
            {
                return null;
            }
            else
            {
                var cover = Path.Combine(imagePath, game.Cover);
                File.Delete(cover);
                return null;
            }
        }
        public bool Delete(int id)
        {
            var isDeleted = false;

            var game = _context.games.Find(id);

            if (game is null)
                return isDeleted;

            _context.Remove(game);
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;

                var cover = Path.Combine(imagePath, game.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }
        private async Task<string> SaveCover(IFormFile cover)
        {
            var coveName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(imagePath, coveName);
            //save in server
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            return coveName;
        }
    }
}
