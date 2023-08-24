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
				Console.Write('\u25a1'); // □
			Console.SetCursorPosition(0, mapHeight + 1);
			for (int col = 0; col < edgeWidth; col++)
				Console.Write('\u25a1'); // □

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
	}
}

