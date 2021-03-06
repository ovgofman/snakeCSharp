using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Shape
    {
        protected List<Point> _points;

        public void DrawLine()
        {
            foreach (Point point in _points)
            {
                point.DrawPoint();
            }
        }

        public bool Collision(Shape shape)
        {
            foreach (var item in _points)
            {
                if (shape.ComparePoints(item))
                    return true;
            }

            return false;
        }

        private bool ComparePoints(Point point)
        {
            foreach (var item in _points)
            {
                if (point.ComparePoints(item))
                    return true;
            }

            return false;
        }
    }
}