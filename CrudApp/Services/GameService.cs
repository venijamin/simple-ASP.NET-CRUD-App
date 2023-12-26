using CrudApp.Data;
using CrudApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Services;

public class GameService : IGameService
{
    private readonly DataContext _dataContext;

    public GameService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Game>> getAllGames()
    {
        var games = await _dataContext.Games.ToListAsync();
        return games;
    }

    public async Task<Game> getGameById(int id)
    {
        Game? game = await _dataContext.Games.FirstOrDefaultAsync(x => x.Id == id);
        return game;
    }

    public async Task<bool> deleteGame(int id)
    {
        Game game = await _dataContext.Games.FindAsync(id);
        if (game != null)
        {
            _dataContext.Games.Remove(game);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Game> editGame(Game game, int id)
    {
        Game gameToEdit = _dataContext.Games.FirstOrDefault(x => x.Id == id);
        gameToEdit.Name = game.Name;
        _dataContext.Games.Update(gameToEdit);
        await _dataContext.SaveChangesAsync();
        return gameToEdit;
    }

    public async Task<Game> addGame(Game game)
    {
        _dataContext.Add(game);
        await _dataContext.SaveChangesAsync();
        return game;
    }
}