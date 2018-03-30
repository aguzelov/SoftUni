using P09_InfernoInfinity.Contracts;
using System.Collections.Generic;

namespace P09_InfernoInfinity.Models.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get => this.data;
            private set => this.data = value;
        }

        public abstract void Execute(List<IWeapon> weapons);
    }
}