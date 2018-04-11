public interface ISubject
{
    void Regster(IObserver observer);

    void Unregister(IObserver observer);

    void NotifyObservers();
}