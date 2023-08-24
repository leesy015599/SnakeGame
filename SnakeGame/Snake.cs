namespace SnakeGame
{
	public class Snake
	{
		// private field
		private int _headTo;
		private List<Point> _bodyPartList;

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

		public List<Point> BodyPartList
		{
			get { return _bodyPartList; }
		}

		// constructor
		public Snake()
		{
			_bodyPartList = new();
		}

		public void AddBody(Point newPart)
		{
			_bodyPartList.Add(newPart);
		}
	}
}

