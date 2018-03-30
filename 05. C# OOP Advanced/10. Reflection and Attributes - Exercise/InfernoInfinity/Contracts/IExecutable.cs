using P09_InfernoInfinity.Models.Weapons;
using System.Collections.Generic;

namespace P09_InfernoInfinity.Contracts
{
    public interface IExecutable
    {
        void Execute(List<Weapon> weapons);
    }
}