using System.Collections.Generic;
using ConsoleApp1.Lines;

namespace ConsoleApp1.Installers
{
    public class LineInstaller
    {
        private List<Shape> _shapes;

        public LineInstaller()
        {
            _shapes = new List<Shape>();

            HorizontalLine top = new HorizontalLine(0, 0, 120, '-');
            HorizontalLine bottom = new HorizontalLine(0, 20, 120, '-');
            VerticalLine left = new VerticalLine(0, 1, 20, '|');
            VerticalLine right = new VerticalLine(119, 1, 20, '|');

            _shapes.AddRange(new List<Shape> {top, bottom, left, right});
        }

        public void DrawShapes()
        {
            foreach (var item in _shapes)
            {
                item.DrawLine();
            }
        }

        public bool Collision(Shape shape)
        {
            foreach (var item in _shapes)
            {
                if (item.Collision(shape))
                    return true;
            }

            return false;
        }
    }
}