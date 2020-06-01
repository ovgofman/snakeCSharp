using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using ConsoleApp1.UserServices;

namespace ConsoleApp1.UI
{
    public class UIService
    {
        private GamePlay _gamePlay = new GamePlay();
        private UserService _userService = new UserService();
        private User _user = new User();

        public void GetMenu()
        {
            Console.Clear();

            Console.SetCursorPosition(30, 7);
            Console.WriteLine("Welcome to snake game");

            Console.SetCursorPosition(30, 11);
            Console.WriteLine("- Press Enter to start the game");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("- Use arrows to move the snake");
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("- Press C to create the user");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("- Press S to get all scores");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("- Press ESC to quite the game");
        }


        public void GetCommand(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    StartGame();
                    break;
                case ConsoleKey.C:
                    CreateUserFrom();
                    break;
                case ConsoleKey.S:
                    ScoreBoard();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    GetMenu();
                    break;
            }
        }

        private void StartGame()
        {
            Console.Clear();
            _gamePlay.StartGame(_user);
            Concede();
        }

        private void CreateUserFrom()
        {
            Console.Clear();
            Console.WriteLine("User form");

            Label:
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            try
            {
                _user = _userService.CreateUser(userName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Label;
            }

            Console.WriteLine("User was added");
            Console.WriteLine("Press Backspace to get back");
        }

        private void ScoreBoard()
        {
            Console.Clear();
            Console.WriteLine("Score");

            IEnumerable<User> users = _userService.GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} with score {user.Score}");
            }

            Console.WriteLine("Press Backspace to get back");
        }

        private void Concede()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("to try again press Enter");
            Console.WriteLine("Back to menu press Backspace");
        }
    }
}