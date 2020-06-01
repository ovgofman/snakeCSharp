using System.Collections.Generic;

namespace ConsoleApp1.Lines
{
    public class VerticalLine : Shape
    {
        public VerticalLine(int left, int top, int count, char symbol)
        {
            _points = new List<Point>();

            for (int i = top; i < count; i++)
            {
                Point point = new Point(left, i, symbol);
                _points.Add(point);
            }
        }
    }
}