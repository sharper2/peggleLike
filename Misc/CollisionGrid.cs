using System.Collections.Generic;
using PhysicsLibrary.Sprites;

namespace PhysicsLibrary.Misc
{
    public class CollisionGrid
    {
        private int _rows;
        private int _columns;

        private float _width;
        private float _height;

        private float _cellWidth;
        private float _cellHeight;

        private Peg[] _unsortedPegs;
        private Dictionary<int, Peg> _sortedPegs;

        public CollisionGrid(int rows, int columns, float width, float height, Peg[] pegs)
        {
            _rows = rows;
            _columns = columns;
            _width = width;
            _height = height;
            _unsortedPegs = pegs;

            _cellWidth = _width / _columns;
            _cellHeight = _height / _rows;
        }

        private void setGrid()
        {
            foreach (Peg p in _unsortedPegs)
            {
                int row = getRow(p.Position.Y);
                int column = getColumn(p.Position.X);
                int index = getCellIndex(row, column);
                _sortedPegs.Add(index, p);
            }
        }

        private int getRow(float y)
        {
            for (int i = 0; i < _rows; i++)
            {
                if (y >= i * _cellHeight && y <= (i+1) * _cellHeight)
                    return i;
            }

            return -1;
        }

        private int getColumn(float x)
        {
            for (int i = 0; i < _columns; i++)
            {
                if (x >= i * _cellWidth && x <= (i+1) * _cellWidth)
                    return i;
            }

            return -1;
        }

        private int getCellIndex(int row, int column)
        {
            return (row * _columns) + column;
        }
    }
}