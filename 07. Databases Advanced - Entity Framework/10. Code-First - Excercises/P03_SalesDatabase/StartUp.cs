using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data;
using System;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SalesContext())
            {
                context.Database.EnsureDeleted();

                context.Database.Migrate();
            }
        }
    }
}