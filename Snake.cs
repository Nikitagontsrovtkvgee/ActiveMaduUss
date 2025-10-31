using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Snake
    {
        public List<Position> Body { get; private set; }
        private Direction dir;
        public bool IsBooster { get; private set; } = false;
        private bool alive = true;

        public Snake(Position start, Direction direction, int length)
        {
            Body = new List<Position>();
            dir = direction;
            for (int i = 0; i < length; i++)
                Body.Add(new Position(start.X - i, start.Y));
        }

        public void SetDirection(Direction d)
        {
            dir = d;
        }

        public void Move()
        {
            if (!alive) return;

            Position head = Body[0].Copy();
            switch (dir)
            {
                case Direction.Up: head.Y--; break;
                case Direction.Down: head.Y++; break;
                case Direction.Left: head.X--; break;
                case Direction.Right: head.X++; break;
            }

            Body.Insert(0, head);
            Body.RemoveAt(Body.Count - 1);
        }

        public void MoveMirror(Position target)
        {
            if (!alive) return;
            Position head = Body[0].Copy();
            if (target.X > head.X) head.X++;
            else if (target.X < head.X) head.X--;
            if (target.Y > head.Y) head.Y++;
            else if (target.Y < head.Y) head.Y--;
            Body.Insert(0, head);
            Body.RemoveAt(Body.Count - 1);
        }

        public void Grow()
        {
            Position tail = Body[Body.Count - 1].Copy();
            Body.Add(tail);
        }

        public bool CheckSelfCollision()
        {
            Position head = Body[0];
            for (int i = 1; i < Body.Count; i++)
                if (head.Equals(Body[i])) return true;
            return false;
        }

        public bool CheckWallCollision(int width, int height)
        {
            Position head = Body[0];
            return head.X <= 0 || head.Y <= 0 || head.X >= width - 1 || head.Y >= height - 1;
        }

        public bool IsHit(Snake other)
        {
            foreach (var part in other.Body)
                if (Body[0].Equals(part)) return true;
            return false;
        }

        public void ActivateBooster()
        {
            IsBooster = true;
        }

        public void Kill()
        {
            alive = false;
        }
    }
}
