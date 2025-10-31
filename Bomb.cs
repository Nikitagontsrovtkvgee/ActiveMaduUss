using System;

namespace SnakeGame
{
    public class Bomb
    {
        public Position Pos { get; private set; }
        private int dx, dy;
        private Random random = new Random();

        public char Symbol { get; private set; } = 'X';

        public Bomb(int x, int y)
        {
            Pos = new Position(x, y);
            dx = random.Next(-1, 2);
            dy = random.Next(-1, 2);
            if (dx == 0 && dy == 0) dx = 1;
        }

        public void Move(int width, int height)
        {
            Pos.X += dx;
            Pos.Y += dy;

            if (Pos.X <= 1 || Pos.X >= width - 2) dx *= -1;
            if (Pos.Y <= 1 || Pos.Y >= height - 2) dy *= -1;
        }

        public bool IsHitSnake(Snake snake)
        {
            foreach (var part in snake.Body)
                if (Pos.Equals(part)) return true;
            return false;
        }
    }
}
