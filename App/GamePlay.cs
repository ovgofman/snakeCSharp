using System;
using System.Threading;
using ConsoleApp1.Enums;
using ConsoleApp1.Factory;
using ConsoleApp1.Helpers;
using ConsoleApp1.Installers;
using ConsoleApp1.UserServices;

namespace ConsoleApp1
{
    public class GamePlay
    {
        private UserService _userService = new UserService();
        private Point food;

        public void StartGame(User user)
        {
            if (user == null)
                user = new User();

            int score = 0;
            LineInstaller line = new LineInstaller();
            line.DrawShapes();

            var food = GetFood();

            Snake snake = new Snake();
            snake.CreateSnake(5, new Point(10, 5, '*'), DirectionEnum.Right);
            snake.DrawLine();


            ScoreHelper.GetScore(score);

            while (true)
            {
                if (line.Collision(snake) || snake.CollisionWithTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    score++;
                    ScoreHelper.GetScore(score);

                    food = GetFood();
                }

                Thread.Sleep(100);
                snake.Move();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.PressKey(key.Key);
                }
            }

            user.Score = score;
            _userService.SaveScore(user);
        }

        private Point GetFood()
        {
            food = FoodFactory.GetRandomFood(119, 20, '$');
            Console.ForegroundColor = ColorHelper.GetRandomColor(new Random().Next(1, 5));
            food.DrawPoint();
            Console.ResetColor();
            return food;
        }
    }
}