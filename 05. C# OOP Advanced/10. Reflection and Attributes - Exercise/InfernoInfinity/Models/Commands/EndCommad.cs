using P09_InfernoInfinity.Models.Weapons;
using System;
using System.Collections.Generic;

namespace P09_InfernoInfinity.Models.Commands
{
    public class EndCommad : Command
    {
        public EndCommad(string[] data) : base(data)
        {
        }

        public override void Execute(List<Weapon> weapons)
        {
            Environment.Exit(0);
        }
    }
}