using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_on_console.Models
{
    public class Pawn : PieceBaseModel
    {

        public Pawn(bool isWhite)
        {
            IsWhite = isWhite;
            Image = isWhite ? "♙" : "♟";
        }

        public override bool MovePiece(Tuple<int, int>fromBlock, Tuple<int, int> toBlock, PieceBaseModel[,] grid)
        {
            //item2 is row item 1 is column
            bool validMoveForward = IsWhite ? fromBlock.Item1 - toBlock.Item1 <=2 : toBlock.Item1 -  fromBlock.Item1 <= 2;
            if (toBlock.Item2 == fromBlock.Item2 && validMoveForward && grid[toBlock.Item1, toBlock.Item2] == null)
            {
                grid[fromBlock.Item1, fromBlock.Item2] = null;
                grid[toBlock.Item1, toBlock.Item2] = this;
                return true;
            }
            var validateColumnDifference = Math.Abs(toBlock.Item1 - fromBlock.Item1) == 1;
            if (validateColumnDifference && grid[toBlock.Item1, toBlock.Item2] != null)
            {
                grid[fromBlock.Item1, fromBlock.Item2] = null;
                grid[toBlock.Item1, toBlock.Item2] = this;
                return true;
            }
            return false;
        }
    }
}
