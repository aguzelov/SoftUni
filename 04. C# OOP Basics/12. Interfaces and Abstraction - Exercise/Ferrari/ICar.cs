public interface ICar
{
    string Driver { get; set; }
    string Model { get; set; }

    string PushBreake();

    string PushGas();
}