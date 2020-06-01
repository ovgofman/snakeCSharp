using System.Collections.Generic;

namespace ConsoleApp1.Lines
{
    public class HorizontalLine : Shape
    {
        public HorizontalLine(int left, int top, int count, char symbol)
        {
            _points = new List<Point>();

            for (int i = left; i < count; i++)
            {
                Point point = new Point(i, top, symbol);
                _points.Add(point);
            }
        }
    }
}