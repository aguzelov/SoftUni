using Forum.App.Contracts;

namespace Forum.App.Models.Commands
{
    public class ViewPostMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public ViewPostMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);
            if (menu is IIdHoldingMenu holdingMenu)
            {
                int id = int.Parse(args[0]);
                holdingMenu.SetId(id);
            }
            menu.Open();

            return menu;
        }
    }
}