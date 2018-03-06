namespace Forum.App.UserInterface.Contracts
{
    public interface ILabel : IPositionable
    {
        string Text { get; }

        bool IsHidden { get; }
    }
}