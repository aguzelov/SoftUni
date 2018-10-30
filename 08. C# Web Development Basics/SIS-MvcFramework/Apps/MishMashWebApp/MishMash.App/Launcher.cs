using Microsoft.EntityFrameworkCore;
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
            context.Database.Migrate();

            WebHost.Start(new StartUp());

            Console.WriteLine("Hello World!");
        }
    }
}