using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public class Snake : Shape
    {
        DirectionEnum _direction;

        public Snake()
        {
            _points = new List<Point>();
        }

        public void CreateSnake(int length, Point snakeTail, DirectionEnum direction)
        {
            _direction = direction;
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(snakeTail);
                p.setDirection(i, direction);
                _points.Add(p);
            }
        }

        public void Move()
        {
            Point tail = _points.First();
            _points.Remove(tail);

            Point head = new Point(_points.Last());
            head.setDirection(1, _direction);
            _points.Add(head);

            tail.ClearPoint();
            head.DrawPoint();
        }

        public void PressKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                _direction = DirectionEnum.Left;
            else if (key == ConsoleKey.RightArrow)
                _direction = DirectionEnum.Right;
            else if (key == ConsoleKey.UpArrow)
                _direction = DirectionEnum.Up;
            else if (key == ConsoleKey.DownArrow)
                _direction = DirectionEnum.Down;
        }

        public bool CollisionWithTail()
        {
            Point head = _points.Last();

            for (int i = 0; i < _points.Count - 1; i++)
            {
                if (head.ComparePoints(_points[i]))
                    return true;
            }

            return false;
        }

        public bool Eat(Point food)
        {
            Point head = new Point(_points.Last());
            head.setDirection(1, _direction);

            if (head.ComparePoints(food))
            {
                food.Symbol = head.Symbol;
                _points.Add(food);
                return true;
            }

            return false;
        }
    }
}