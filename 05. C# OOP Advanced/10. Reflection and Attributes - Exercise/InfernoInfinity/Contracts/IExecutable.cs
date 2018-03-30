using System.Collections.Generic;

namespace P09_InfernoInfinity.Contracts
{
    public interface IExecutable
    {
        void Execute(List<IWeapon> weapons);
    }
}