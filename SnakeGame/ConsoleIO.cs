namespace SnakeGame
{
	public class ConsoleIO
	{
		public ConsoleIO()
		{
		}

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
				Console.SetCursorPosition(0, row);
				Console.Write('\u25a1'); // □
				Console.SetCursorPosition(mapWidth + 1, row);
				Console.Write('\u25a1'); // □
			}
		}

		public static void PrintSnake(Snake snake)
		{
			List<Snake.Part> body = snake.Body;
			char snakeHeadSymbol;

			switch ((Snake.Direction)snake.HeadTo)
			{
				case Snake.Direction.East:
					snakeHeadSymbol = Symbol.snakeEast;
					break;
				case Snake.Direction.West:
					snakeHeadSymbol = Symbol.snakeWest;
					break;
				case Snake.Direction.South:
					snakeHeadSymbol = Symbol.snakeSouth;
					break;
				default: // Direction.North
					snakeHeadSymbol = Symbol.snakeNorth;
					break;
			}
			PrintPoint(body[0].Row, body[0].Col, snakeHeadSymbol);

			for (int index = 1; index < body.Count; index++)
				PrintPoint(body[index].Row, body[index].Col, Symbol.snakeBody);
		}

		private static void PrintPoint(int row, int col, char symbol)
		{
			Console.SetCursorPosition(col, row);
			Console.Write(symbol);
		}
	}
}

