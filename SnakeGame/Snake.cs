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

		// method
		public void AddBody(Point newPart)
		{
			_bodyPartList.Add(newPart);
		}

		public bool IsHit()
		{
			Point head = _bodyPartList[0];

			if (OnFood(head))
				return true;
			if (OnMapEdge(head) || OnBody(head))
			{
				Program.isGameOver = true;
				return true;
			}			
			return false;
		}

		private bool OnFood(Point head)
		{
			if ((head.Col == Program.food.Col)
				&& (head.Row == Program.food.Row))
			{
				return true;
			}
			return false;
		}

		private bool OnMapEdge(Point head)
		{
			if (((head.Col == 0) || (head.Col == Program.mapWidth + 1))
				|| ((head.Row == 0) || (head.Row == Program.mapHeight + 1)))
			{
				return true;
			}
			return false;
		}

		private bool OnBody(Point head)
		{
			for (int index = 1; index < _bodyPartList.Count; index++)
			{
				if ((_bodyPartList[index].Col == head.Col)
					&& (_bodyPartList[index].Row == head.Row))
					return true;
			}
			return false;
		}

		public void KeyPressed(ConsoleKeyInfo key)
		{
			int newHeadTo;

			switch (key.Key)
			{
				case ConsoleKey.RightArrow:
					newHeadTo = (int)Direction.East;
					break;
				case ConsoleKey.LeftArrow:
					newHeadTo = (int)Direction.West;
					break;
				case ConsoleKey.DownArrow:
					newHeadTo = (int)Direction.South;
					break;
				default: // Key.UpArrow
					newHeadTo = (int)Direction.North;
					break;
			}
			SetDirection(newHeadTo);
		}

		private void SetDirection(int newHeadTo)
		{
			if ((_headTo == (int)Direction.East)
				|| (_headTo == (int)Direction.West))
			{
				if ((newHeadTo == (int)Direction.South)
					|| (newHeadTo == (int)Direction.North))
				{
					_headTo = newHeadTo;
				}
			}
			else if ((_headTo == (int)Direction.South)
					 || (_headTo == (int)Direction.North))
			{
				if ((newHeadTo == (int)Direction.East)
					|| (newHeadTo == (int)Direction.West))
				{
					_headTo = newHeadTo;
				}
			}
		}

		public void Move(ref Point lastPart)
		{
			Point head = _bodyPartList[0];
			Point prevPart = new Point(head.Col, head.Row, head.Symbol);
			Point currPart = new(0, 0, ' ');
			Point tempPart = new(0, 0, ' ');

			switch ((Direction)_headTo)
			{
				case Direction.East:
					head.Col++;
					break;
				case Direction.West:
					head.Col--;
					break;
				case Direction.South:
					head.Row++;
					break;
				case Direction.North:
					head.Row--;
					break;
			}

			for (int index = 1; index < _bodyPartList.Count; index++)
			{
				currPart = _bodyPartList[index];
				// Console.Write($"[{currPart.Col},{currPart.Row}] -> ");
				tempPart.Col = currPart.Col;
				tempPart.Row = currPart.Row;
				currPart.Col = prevPart.Col;
				currPart.Row = prevPart.Row;
				// Console.WriteLine($"[{currPart.Col},{currPart.Row}]");
				prevPart.Col = tempPart.Col;
				prevPart.Row = tempPart.Row;
			}
			lastPart.Col = prevPart.Col;
			lastPart.Row = prevPart.Row;
		}

		public void AteFood(Point lastPart)
		{
			Point newPart = new Point(lastPart.Col, lastPart.Row, lastPart.Symbol);
			_bodyPartList.Add(newPart);
			Program.foodCount += 1;
		}
	}
}

