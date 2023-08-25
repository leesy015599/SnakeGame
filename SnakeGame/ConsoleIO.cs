namespace SnakeGame
{
	public class ConsoleIO
	{
		public static void PrintMapEdge(int mapWidth, int mapHeight)
		{
			int edgeWidth = mapWidth + 2;
			int edgeHeight = mapHeight + 2;

			Console.SetCursorPosition(0, 0);
			for (int col = 0; col < edgeWidth; col++)
				Console.Write(Symbol.mapEdge);
			Console.SetCursorPosition(0, mapHeight + 1);
			for (int col = 0; col < edgeWidth; col++)
				Console.Write(Symbol.mapEdge);

			for (int row = 0; row < edgeHeight; row++)
			{
				PrintPoint(0, row, Symbol.mapEdge);
				PrintPoint(mapWidth + 1, row, Symbol.mapEdge);
			}
		}

		public static void PrintSnake(Snake snake)
		{
			List<Point> bodyPart = snake.BodyPartList;
			
			PrintHead(snake, bodyPart[0]);

			for (int index = 1; index < bodyPart.Count; index++)
				PrintPoint(bodyPart[index].Col, bodyPart[index].Row, Symbol.snakeBody);
		}

		public static void PrintHead(Snake snake, Point head)
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
			bodyPart[0].Symbol = snakeHeadSymbol;
			if (head.Symbol == ' ')
			{
				PrintPoint(head.Col, head.Row, snakeHeadSymbol);
				return ;
			}
			PrintPoint(bodyPart[0].Col, bodyPart[0].Row, snakeHeadSymbol);
		}

		public static void PrintPoint(int col, int row, char symbol)
		{
			Console.SetCursorPosition(col, row);
			Console.Write(symbol);
		}

		public static ConsoleKeyInfo PressedKey()
		{
			ConsoleKeyInfo key = Console.ReadKey(true);
			return key;
		}

		public static void GameOver()
		{
			string gameOver = "- G A M E O V E R -";
			int strlen = gameOver.Length;
			Console.SetCursorPosition(Program.mapWidth / 2 - strlen / 2,
									  Program.mapHeight + 2);
			Console.Write(gameOver);
		}

		public static void PrintScore(int w, int h)
		{
			Console.SetCursorPosition(1, h + 2);
			Console.Write('\uf8ff');
			Console.Write($" : {Program.foodCount}");
		}
	}
}

