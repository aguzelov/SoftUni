﻿namespace Forum.App.Models.Commands
{
    using Forum.App.Contracts;

    public class BackCommand : ICommand
    {
        private ISession session;

        public BackCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            IMenu menu = this.session.Back();
            return menu;
        }
    }
}