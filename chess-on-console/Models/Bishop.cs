using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_on_console.Models
{
    public class Bishop: PieceBaseModel
    {
        public Bishop(bool isWhite) {
            IsWhite = isWhite;

            Image = isWhite ? "♗" : "♝";
        }


    }
}
