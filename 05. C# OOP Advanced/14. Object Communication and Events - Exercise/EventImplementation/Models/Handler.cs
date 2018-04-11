public class Handler
{
    public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
    {
        System.Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
    }
}