using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_on_console.Models
{
    public class King : PieceBaseModel
    {
        public King(bool isWhite) {
            IsWhite = isWhite;

            Image = isWhite ? "♔" : "♚";
        }
    }
}
