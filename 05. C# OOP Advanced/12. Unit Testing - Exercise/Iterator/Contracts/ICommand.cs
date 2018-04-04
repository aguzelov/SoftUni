namespace Iterator.Contracts
{
    public interface ICommand
    {
        void Execute(ref ListIterator list);
    }
}