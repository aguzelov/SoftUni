using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Linq;

namespace PhotoShare.Services
{
    public class UserService : IUserService
    {
        private readonly PhotoShareContext context;
        private readonly ITownService townService;

        public UserService(PhotoShareContext context, ITownService townService)
        {
            this.context = context;
            this.townService = townService;
        }

        public User GetUserByUsername(string username)
        {
            if (!Exist(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            return context.Users.First(u => u.Username == username);
        }

        public User GetsUserByUsernameAndPassword(string username, string password)
        {
            if (!Exist(username, password))
            {
                throw new ArgumentException("Invalid username or password!");
            }

            User user = context.Users.First(u => u.Username == username);

            return user;
        }

        public User CreateUser(string username, string password, string repPassword, string email)
        {
            if (Exist(username))
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }

            if (password != repPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public User ModifyUser(string username, string property, string newValue)
        {
            if (!Exist(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            User user = null;
            if (property == "Password")
            {
                user = ChangePassword(username, newValue);
            }
            else if (property == "BornTown")
            {
                user = ChangeBornTown(username, newValue);
            }
            else if (property == "CurrentTown")
            {
                user = ChangeCurrentTown(username, newValue);
            }

            return user;
        }

        public void DeleteUser(string username)
        {
            if (!Exist(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var user = context.Users.FirstOrDefault(u => u.Username == username);

            if (user.IsDeleted == true)
            {
                throw new InvalidOperationException($"User {username} is already deleted!");
            }

            user.IsDeleted = true;

            // TODO: Delete User by username (only mark him as inactive)
            context.SaveChanges();
        }

        public bool Exist(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }

        public bool Exist(string username, string password)
        {
            return context.Users.Any(u => u.Username == username && u.Password == password);
        }

        private User ChangeCurrentTown(string username, string townName)
        {
            if (!townService.Exist(townName))
            {
                throw new ArgumentException($"Value {townName} not valid.{Environment.NewLine}" +
                    $"Town {townName} not found!");
            }

            User user = context.Users.First(u => u.Username == username);
            user.CurrentTown.Name = townName;

            context.SaveChanges();

            return user;
        }

        private User ChangeBornTown(string username, string townName)
        {
            if (!townService.Exist(townName))
            {
                throw new ArgumentException($"Value {townName} not valid.{Environment.NewLine}" +
                    $"Town {townName} not found!");
            }

            User user = context.Users
                .Include(u => u.BornTown)
                .First(u => u.Username == username);

            Town town = context.Towns.First(t => t.Name == townName);
            user.BornTown = town;

            context.SaveChanges();

            return user;
        }

        private User ChangePassword(string username, string newPassword)
        {
            if (!newPassword.ToCharArray().Any(c => char.IsDigit(c) || char.IsLower(c)))
            {
                throw new ArgumentException($"Value {newPassword} not valid.{Environment.NewLine}" +
                    $"Invalid Password");
            }

            User user = context.Users.First(u => u.Username == username);
            user.Password = newPassword;

            context.SaveChanges();
            return user;
        }
    }
}