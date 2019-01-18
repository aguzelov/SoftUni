﻿using PandaWebApp.Models;

namespace PandaWebApp.Services
{
    public interface IUserService
    {
        bool Add(string username, string password, string confirmPassword, string email);

        bool Contains(string username, string password);

        User GetUser(string username);
    }
}