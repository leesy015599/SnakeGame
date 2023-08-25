namespace SnakeGame;

enum Direction
{
    East,
    West,
    South,
    North
}

class Program
{
    public static int mapWidth = 40;
    public static int mapHeight = 20;
    public static int defaultSnakeLength = 4;
    public static Snake snake = new();

    public static Point food = new(0, 0, Symbol.food);

    public static Random random = new();

    public static bool isGameOver = false;

    public static int foodCount = 0;

    static void Main()
    {
        Console.Clear();
        ConsoleIO.PrintMapEdge(mapWidth, mapHeight);
        ConsoleIO.PrintScore(mapWidth, mapHeight);
        Initialize();
        Point lastPart = new(0, 0, Symbol.snakeBody);
        while (true)
        {
            if (lastPart.Col != 0)
                ConsoleIO.PrintPoint(lastPart.Col, lastPart.Row, ' ');
            ConsoleIO.PrintSnake(snake);
            ConsoleIO.PrintScore(mapWidth, mapHeight);
        ConsoleIO.PrintPoint(food.Col, food.Row, Symbol.food);
            if (Console.KeyAvailable)
                snake.KeyPressed(ConsoleIO.PressedKey());
            Point prevHead = new Point(snake.BodyPartList[0].Col,
                                       snake.BodyPartList[0].Row,
                                       ' ');
            snake.Move(ref lastPart);
            if (snake.IsHit())
            {
                if (isGameOver == false)
                {
                    FoodCreator.newFoodPosition(snake, ref food);
                    snake.AteFood(lastPart);
                }
                else
                {
                    ConsoleIO.PrintHead(snake, prevHead);
                    break;
                }
            }
            Thread.Sleep(100);
        }
        ConsoleIO.GameOver();

        // Move cursor for proper start of next shell
        Console.SetCursorPosition(0, mapHeight + 3);
    }

    static void Initialize()
    {
        snake.HeadTo = (int)Direction.East;
        for (int index = 0; index < defaultSnakeLength; index++)
            snake.AddBody(new Point(mapWidth / 2 - index,
                                    mapHeight / 2, Symbol.snakeBody));
        food = new Point(mapWidth * 3 / 4, mapHeight / 2, Symbol.food);
    }
}

