namespace P09_InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        void AddGem(int socketIndex, IGem gem);

        void Remove(int socketIndex);
    }
}