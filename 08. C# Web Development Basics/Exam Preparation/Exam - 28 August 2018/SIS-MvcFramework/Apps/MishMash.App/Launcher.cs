using MishMash.Data;
using SIS.MvcFramework;
using System;

namespace MishMash.App
{
    internal class Launcher
    {
        private static void Main(string[] args)
        {
            var context = new MishMashContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            WebHost.Start(new StartUp());

            Console.WriteLine("Hello World!");
        }
    }
}