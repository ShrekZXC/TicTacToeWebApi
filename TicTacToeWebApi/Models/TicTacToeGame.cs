namespace TicTacToeApi.Models;

public class TicTacToeGame
{
    public string GameId { get; set; }
    
    public Player PlayerX { get; set; }
    
    public Player PlayerO { get; set; }
    
    public Player CurrentPlayer { get; set; }
    
    public GameBoard Board { get; set; }
    
    public GameStatus Status { get; set; }
}