using P09_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;

namespace P09_InfernoInfinity.Models.Commands
{
    public class EndCommad : Command
    {
        public EndCommad(string[] data) : base(data)
        {
        }

        public override void Execute(List<IWeapon> weapons)
        {
            Environment.Exit(0);
        }
    }
}