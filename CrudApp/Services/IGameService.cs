using CrudApp.Entity;

namespace CrudApp.Services
{
    public interface IGameService
    {
        Task<List<Game>> getAllGames();
        Task<Game> getGameById(int id);
        Task<bool> deleteGame(int id);
        Task<Game> editGame(Game game, int id);
        Task<Game> addGame(Game game);
    }
}
