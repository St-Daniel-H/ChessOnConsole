using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_on_console.Models
{
    public class PieceBaseModel
    {
        public bool IsWhite { get; set; }

        public bool? IsDead { get; set; }

        public string? PieceName { get; set; }

        public string? Image { get; set; }

        public override string ToString()
        {
            return Image!;
        }

        public virtual bool MovePiece(Tuple<int, int> fromBlock, Tuple<int, int> toBlock, PieceBaseModel[,] grid)
        {
            return false; 
        }
    }
}
