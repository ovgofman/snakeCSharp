using System;

namespace ConsoleApp1.Helpers
{
    public static class ColorHelper
    {
        public static ConsoleColor GetRandomColor(int value)
        {
            switch (value)
            {
                case 1:
                    return ConsoleColor.Blue;
                case 2:
                    return ConsoleColor.Cyan;
                case 3:
                    return ConsoleColor.Green;
                case 4:
                    return ConsoleColor.Magenta;
                case 5:
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}