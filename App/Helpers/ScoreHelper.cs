using System;

namespace ConsoleApp1.Helpers
{
    public static class ScoreHelper
    {
        public static void GetScore(int score)
        {
            Console.SetCursorPosition(2, 22);
            Console.WriteLine($"score: {score}");
        }
    }
}