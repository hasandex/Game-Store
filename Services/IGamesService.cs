using GameZone.Models;
using GameZone.ViewModel;

namespace GameZone.Services
{
    public interface IGamesService
    {
        public Task Create(CreateGameFormViewModel game);
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task<Game?> Update(EditGameFormViewModel game);
        bool Delete(int id);
    }
}
