using System;

namespace ConsoleApp1.Factory
{
    public static class FoodFactory
    {
        private static Random _random = new Random();

        public static Point GetRandomFood(int spaceWidth, int spaceHeight, char symbol)
        {
            spaceWidth = _random.Next(2, spaceWidth - 2);
            spaceHeight = _random.Next(2, spaceHeight - 2);

            return new Point(spaceWidth, spaceHeight, symbol);
        }
    }
}