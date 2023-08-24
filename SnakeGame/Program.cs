using System.Numerics;

namespace SnakeGame;

public static class Symbol
{
    public static char mapEdge = '\u25a1'; // □
    public static char snakeEast = '\u25b6'; // ▶
    public static char snakeWest = '\u25c0'; // ◀
    public static char snakeSouth = '\u25bc'; // ▼
    public static char snakeNorth = '\u25b2'; // ▲
    public static char snakeBody = '\u25cb'; // ○
}

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
            snake.AddBody(new Snake.Part(mapHeight / 2, mapWidth / 2 - index));
    }
}

