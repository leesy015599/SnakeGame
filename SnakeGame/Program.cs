namespace SnakeGame;
class Program
{
    public static int mapWidth = 17;
    public static int mapHeight = 15;
    public static int defaultSnakeLength = 4;
    public static Snake snake = new();

    static void Main()
    {
        Console.Clear();
        ConsoleIO.PrintMapEdge(mapWidth, mapHeight);
        Initialize();
        ConsoleIO.PrintSnake(snake);

        // Move cursor for proper start of next shell
        Console.SetCursorPosition(0, mapHeight + 2);
    }

    static void Initialize()
    {
        snake.HeadTo = (int)Snake.Direction.East;
        for (int index = 0; index < defaultSnakeLength; index++)
            snake.AddBody(new Point(mapWidth / 2 - index, mapHeight / 2));
    }
}

