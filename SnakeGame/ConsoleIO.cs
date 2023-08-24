namespace SnakeGame
{
	public class ConsoleIO
	{
		public static void PrintMapEdge(int mapWidth, int mapHeight)
		{
			// 위 아래 가로줄
			int edgeWidth = mapWidth + 2;
			Console.SetCursorPosition(0, 0);
			for (int col = 0; col < edgeWidth; col++)
				Console.Write(Symbol.mapEdge);
			Console.SetCursorPosition(0, mapHeight + 1);
			for (int col = 0; col < edgeWidth; col++)
				Console.Write(Symbol.mapEdge);

			// 좌 우 세로줄
			int edgeHeight = mapHeight + 2;
			for (int row = 0; row < edgeHeight; row++)
			{
				PrintPoint(0, row, Symbol.mapEdge);
				PrintPoint(mapWidth + 1, row, Symbol.mapEdge);
			}
		}

		public static void PrintSnake(Snake snake)
		{
			List<Point> bodyPart = snake.BodyPartList;
			char snakeHeadSymbol;

			switch ((Direction)snake.HeadTo)
			{
				case Direction.East:
					snakeHeadSymbol = Symbol.snakeEast;
					break;
				case Direction.West:
					snakeHeadSymbol = Symbol.snakeWest;
					break;
				case Direction.South:
					snakeHeadSymbol = Symbol.snakeSouth;
					break;
				default: // Direction.North
					snakeHeadSymbol = Symbol.snakeNorth;
					break;
			}
			PrintPoint(bodyPart[0].Col, bodyPart[0].Row, snakeHeadSymbol);

			for (int index = 1; index < bodyPart.Count; index++)
				PrintPoint(bodyPart[index].Col, bodyPart[index].Row, Symbol.snakeBody);
		}

		public static void PrintPoint(int col, int row, char symbol)
		{
			Console.SetCursorPosition(col, row);
			Console.Write(symbol);
		}
	}
}

