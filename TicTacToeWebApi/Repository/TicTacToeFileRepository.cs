using System.Text.Json;
using TicTacToeApi.Models;
using TicTacToeApi.Utils;

namespace TicTacToeApi.Repository;

public class TicTacToeFileRepository: ITicTacToeRepository
{
    private readonly string _dataPath;

    public TicTacToeFileRepository(string dataPath)
    {
        _dataPath = dataPath;
    }

    public TicTacToeGame CreateGame(Player playerX, Player playerO)
    {
        var game = new TicTacToeGame();
        var gameId = Guid.NewGuid().ToString();
        var filePath = Path.Combine(_dataPath, $"{gameId}.json");

        game.GameId = gameId;
        game.PlayerX = playerX;
        game.PlayerO = playerO;

        UpdateGame(game);

        return game;
    }

    public TicTacToeGame GetGame(string gameId)
    {
        var filePath = Path.Combine(_dataPath, $"{gameId}.json");

        if (!File.Exists(filePath))
        {
            throw new GameNotFoundException($"Game with id {gameId} not found");
        }

        var json = File.ReadAllText(filePath);
        var game = JsonSerializer.Deserialize<TicTacToeGame>(json);

        return game;
    }

    public void UpdateGame(TicTacToeGame game)
    {
        var filePath = Path.Combine(_dataPath, $"{game.GameId}.json");
        var json = JsonSerializer.Serialize(game);

        File.WriteAllText(filePath, json);
    }

    public void DeleteGame(string gameId)
    {
        var filePath = Path.Combine(_dataPath, $"{gameId}.json");

        if (!File.Exists(filePath))
        {
            throw new GameNotFoundException($"Game with id {gameId} not found");
        }

        File.Delete(filePath);
    }
}