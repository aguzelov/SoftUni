using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private bool isRunning;

        private readonly DungeonMaster master;

        public Engine()
        {
            this.master = new DungeonMaster();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string command = Console.ReadLine();
                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Parameter Error: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Invalid Operation: " + e.Message);
                }

                if (this.master.IsGameOver() || this.isRunning == false)
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(this.master.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (commandName)
            {
                case "JoinParty":
                    output = this.master.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = this.master.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = this.master.PickUpItem(args);
                    break;
                case "UseItem":
                    output = this.master.UseItem(args);
                    break;
                case "GiveCharacterItem":
                    output = this.master.GiveCharacterItem(args);
                    break;
                case "UseItemOn":
                    output = this.master.UseItemOn(args);
                    break;
                case "GetStats":
                    output = this.master.GetStats();
                    break;
                case "Attack":
                    output = this.master.Attack(args);
                    break;
                case "Heal":
                    output = this.master.Heal(args);
                    break;
                case "EndTurn":
                    output = this.master.EndTurn(args);
                    break;
            }

            if (output != string.Empty)
            {
                Console.WriteLine(output);
            }
        }
    }
}
