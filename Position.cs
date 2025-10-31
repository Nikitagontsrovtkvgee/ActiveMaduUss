namespace SnakeGame
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Copy()
        {
            return new Position(X, Y);
        }

        public bool Equals(Position other)
        {
            return other != null && X == other.X && Y == other.Y;
        }
    }
}
