namespace SnakeGame
{
    public class Bomb
    {
        private Position pos;
        public char Symbol { get; private set; }
        private int difficulty;
        private Random random = new Random();

        public Bomb(int x, int y, char symbol, int diff)
        {
            pos = new Position(x, y);
            Symbol = symbol;
            difficulty = diff;
        }

        public Position GetPosition() => pos;

        public void Move(int width, int height)
        {
            switch (random.Next(4))
            {
                case 0: if (pos.X + 1 < width - 1) pos.X++; break;
                case 1: if (pos.X - 1 > 0) pos.X--; break;
                case 2: if (pos.Y + 1 < height - 1) pos.Y++; break;
                case 3: if (pos.Y - 1 > 0) pos.Y--; break;
            }
        }

        public bool IsHitSnake(Snake player)
        {
            foreach (var part in player.Body)
                if (pos.Equals(part))
                    return true;
            return false;
        }
    }
}
