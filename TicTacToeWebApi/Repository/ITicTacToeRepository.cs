using TicTacToeApi.Models;

namespace TicTacToeApi.Repository;

public interface ITicTacToeRepository
{
    TicTacToeGame CreateGame(Player playerX, Player playerO);
    TicTacToeGame GetGame(string gameId);
    void UpdateGame(TicTacToeGame game);
    void DeleteGame(string gameId);
}