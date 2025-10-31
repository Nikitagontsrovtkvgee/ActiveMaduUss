using System;

namespace SnakeGame
{
    public class Enemy
    {
        public Position Pos { get; private set; }
        private readonly Random random = new();

        public Enemy(int x, int y)
        {
            Pos = new Position(x, y);
        }

        public void MoveRandom(int width, int height)
        {
            int dir = random.Next(4);
            switch (dir)
            {
                case 0: Pos.Y--; break;
                case 1: Pos.Y++; break;
                case 2: Pos.X--; break;
                case 3: Pos.X++; break;
            }

            if (Pos.X < 1) Pos.X = width - 2;
            if (Pos.X >= width - 1) Pos.X = 1;
            if (Pos.Y < 1) Pos.Y = height - 2;
            if (Pos.Y >= height - 1) Pos.Y = 1;
        }

        public void Draw(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(Pos.X, Pos.Y);
            Console.Write('E');
            Console.ResetColor();
        }
    }
}
