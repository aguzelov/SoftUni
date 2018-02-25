public interface IRemovable
{
    string RemovedElements { get; }

    void Remove();
}