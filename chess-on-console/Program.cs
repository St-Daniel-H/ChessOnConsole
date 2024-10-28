
using chess_on_console.Models;
Console.OutputEncoding = System.Text.Encoding.UTF8;


Player player1 = new Player();
Player player2 = new Player();

Console.WriteLine("Player 1 Enter your name:");
player1.Name = Console.ReadLine();

Console.WriteLine("Player 2 Enter your name:");
player2.Name = Console.ReadLine();

Console.Clear();

Console.WriteLine($"Welcome, {player1.Name} and {player2.Name}! Let's start the game.");

Random random = new Random();
player1.IsWhite =  random.Next(0, 2) == 1;
player2.IsWhite = !player1.IsWhite;

Console.WriteLine($"{((bool)player1.IsWhite ? player1.Name : player2.Name)} is White");
Game game = new Game();
game.Player1 = player1;
game.Player2 = player2;
game.StartGame();
