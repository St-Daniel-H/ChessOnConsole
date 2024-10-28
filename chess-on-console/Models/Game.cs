using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace chess_on_console.Models
{
    public class Game
    {
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public bool IsOver { get; set; } = false;

        PieceBaseModel?[,] Grid = new PieceBaseModel[8, 8];

        public void SetGame()
        {
            Grid[0, 0] = new Rook(false);
            Grid[0, 1] = new Knight(false);
            Grid[0, 2] = new Bishop(false);
            Grid[0, 3] = new King(false);
            Grid[0, 4] = new Queen(false);
            Grid[0, 5] = new Bishop(false);
            Grid[0, 6] = new Knight(false);
            Grid[0, 7] = new Rook(false);
            for (int i = 0; i < 8; i++)
                Grid[1, i] = new Pawn(false);

            for (int i = 0; i < 8; i++)
                Grid[6, i] = new Pawn(true);
            Grid[7, 0] = new Rook(true);
            Grid[7, 1] = new Knight(true);
            Grid[7, 2] = new Bishop(true);
            Grid[7, 3] = new King(true);
            Grid[7, 4] = new Queen(true);
            Grid[7, 5] = new Bishop(true);
            Grid[7, 6] = new Knight(true);
            Grid[7, 7] = new Rook(true);

        }

        public void PrintGame()
        {
            Console.WriteLine("   a    b    c    d    e    f    g    h");

            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{8 - i} ");

                for (int j = 0; j < 8; j++)
                {
                    if (Grid[i, j] != null)
                        Console.Write($" {Grid[i, j]}  |");
                    else
                        Console.Write(" -- |");
                }

                Console.WriteLine($" {8 - i}");
                Console.WriteLine("  ---------------------------------------");
            }

            Console.WriteLine("   a    b    c    d    e    f    g    h");
        }

        public void StartGame()
        {
            SetGame();
            bool player1Turn = Player1.IsWhite;
            while (!IsOver)
            {
                Player player = player1Turn ? Player1 : Player2;
                Console.Clear();
                PrintGame();
                Console.WriteLine($"{(player1Turn ? Player1.Name : Player2.Name)}'s turn(Type the block from and to ex: a1 a2)");
                var input = Console.ReadLine();
                var move = input.Split(" ");
                var from = DecodeMove(move[0]);
                var to = DecodeMove(move[1]);

                var piece = Grid[from.Item1, from.Item2];//item1 = row, item2 = column
                if (piece == null)
                {
                    Console.WriteLine("No piece there");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                if (piece.IsWhite != player.IsWhite)
                {
                    Console.WriteLine("Wront Piece, please play with your pieces");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }


                var result = piece!.MovePiece(from, to, Grid!);
                if (!result)
                {
                    Console.WriteLine("Illegal Move");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                player1Turn = !player1Turn;
            }
        }


        public Tuple<int, int> DecodeMove(string move)
        {
            int firstChar = 0;
            switch (move[0])
            {
                case 'a': firstChar = 0; break;
                case 'b': firstChar = 1; break;
                case 'c': firstChar = 2; break;
                case 'd': firstChar = 3; break;
                case 'e': firstChar = 4; break;
                case 'f': firstChar = 5; break;
                case 'g': firstChar = 6; break;
                case 'h': firstChar = 7; break;
            }

            int row = 8 - int.Parse(move[1].ToString()); if (row < 0 || row > 7)
            {
                throw new ArgumentOutOfRangeException("Row must be between '1' and '8'.");
            }

            return Tuple.Create(row, firstChar);
        }
    }

    //public void MovePiece(string from, string to)
    //{

    //}
}
