﻿namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using System;

    public class CategoriesController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public int CurrentPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MenuState ExecuteCommand(int index)
        {
            throw new NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new NotImplementedException();
        }
    }
}