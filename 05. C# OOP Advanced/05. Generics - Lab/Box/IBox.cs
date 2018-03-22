public interface IBox<T>
{
    void Add(T element);

    T Remove();

    int Count { get; }
}