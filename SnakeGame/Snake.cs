namespace SnakeGame
{
	public class Snake
	{
		public class Part
		{
			// private field
			private int _row;
			private int _col;

			// public property
			public int Row
			{
				get { return _row; }
				set
				{
					if ((0 < value) && (value < Program.mapHeight + 1))
						_row = value;
				}
			}

			public int Col
			{
				get { return _col; }
				set
				{
					if ((0 < value) && (value < Program.mapWidth + 1))
						_col = value;
				}
			}

			// constructor
			private Part() {}

			public Part(int row, int col)
			{
				Row = row;
				Col = col;
			}
		}

		private int _headTo;
		private List<Part> _body;

		// public property
		public int HeadTo
		{
			get { return _headTo; }
			set
			{
				if (((int)Direction.East <= value)
					&& (value <= (int)Direction.South))
				{
					_headTo = value;
				}
			}
		}

		public List<Part> Body
		{
			get { return _body; }
		}

		// enum
		public enum Direction
		{
			East,
			West,
			South,
			North
		}

		// constructor
		public Snake()
		{
			_body = new();
		}

		public void AddBody(Part newPart)
		{
			_body.Add(newPart);
		}
	}
}

