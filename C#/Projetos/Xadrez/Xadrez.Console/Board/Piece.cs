using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Board
{
    public class Piece
    {
        public int NumberOfMovements { get; protected set; }
        public Color Color { get; protected set; }
        public Board Board { get; set; }
        public Position Position { get; set; }

        public Piece(Position position, Board board, Color color)
        {
            Position = position;
            Board = board;
            Color = color;
            NumberOfMovements = 0;
        }
    }
}
