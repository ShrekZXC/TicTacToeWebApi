using Microsoft.AspNetCore.Mvc;
using TicTacToeApi.Models;
using TicTacToeApi.Repository;

namespace TicTacToeApi.Controllers;

public class TicTacToeController: Controller
{
    private readonly ITicTacToeRepository _repository;

    public TicTacToeController(ITicTacToeRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("{gameId}")]
    public ActionResult MakeMove(string gameId, [FromBody] Move move)
    {
        var game = _repository.GetGame(gameId);
        if (game == null)
        {
            return NotFound();
        }

        if (game.Status != GameStatus.InProgress)
        {
            return BadRequest("Игра уже закончена");
        }

        if (game.CurrentPlayer.Name != move.PlayerName)
        {
            return BadRequest("Ход не от текущего игрока");
        }

        int x = move.Position[0];
        int y = move.Position[1];

        if (game.Board.Board[x, y] != null)
        {
            return BadRequest("Клетка уже занята");
        }

        game.Board.Board[x, y] = game.CurrentPlayer.Symbol;
        
        _repository.UpdateGame(game);

        return Ok();
    }

    [HttpGet("{gameId}")]
    public ActionResult<TicTacToeGame> GetGame(string gameId)
    {
        var game = _repository.GetGame(gameId);
        if (game == null)
        {
            return NotFound();
        }

        return Ok(game);
    }

    [HttpDelete("{gameId}")]
    public ActionResult CancelGame(string gameId)
    {
        _repository.DeleteGame(gameId);
        return Ok();
    }
    
}