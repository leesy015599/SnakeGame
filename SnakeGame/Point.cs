namespace SnakeGame
{
    public class Point
    {
        // private field
        private int _col;
        private int _row;

		// public property
        public int Col
        {
            get { return _col; }
            set
            {
                if ((0 < value) && (value < Program.mapWidth + 1))
                    _col = value;
            }
        }

        public int Row
        {
            get { return _row; }
            set
            {
                if ((0 < value) && (value < Program.mapHeight + 1))
                    _row = value;
            }
        }

        // constructor
        private Point() { }

        public Point(int col, int row)
        {
            Col = col;
            Row = row;
        }
    }
}

