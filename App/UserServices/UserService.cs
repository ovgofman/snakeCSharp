using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.UserServices
{
    public class UserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = UserInitializer.GetSampleUserData();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users.OrderByDescending(user => user.Score);
        }

        public User CreateUser(string name)
        {
            User user = new User();

            var existUser = _users.Select(u => u.Name);
            try
            {
                if (name == "")
                    throw new ArgumentException("Name is empty");
                if (existUser.Contains(name))
                    throw new ArgumentException("User exists");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            user.Name = name;
            _users.Add(user);

            return user;
        }

        public void SaveScore(User user)
        {
            if (user.Name == null)
                return;

            _users.Add(user);
        }
    }
}