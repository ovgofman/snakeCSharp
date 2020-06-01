using System;
using ConsoleApp1.UI;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            UIService service = new UIService();
            service.GetMenu();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                service.GetCommand(keyInfo.Key);
            }
        }
    }
}