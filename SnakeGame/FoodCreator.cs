namespace SnakeGame
{
	public class FoodCreator
	{
		// method
		public static void newFoodPosition(Snake snake, ref Point food)
		{
			int newCol;
			int newRow;
			bool isOnSnake;

			while (true)
			{
				isOnSnake = false;
				newCol = Program.random.Next(1, Program.mapWidth + 1);
				newRow = Program.random.Next(1, Program.mapHeight + 1);
				for (int index = 0; index < snake.BodyPartList.Count(); index++)
				{
					if ((snake.BodyPartList[index].Col == newCol)
						&& (snake.BodyPartList[index].Row == newRow))
					{
						isOnSnake = true;
						break;
					}
				}
				if (isOnSnake == false)
					break;
			}
			food.Col = newCol;
			food.Row = newRow;
		}
	}
}

