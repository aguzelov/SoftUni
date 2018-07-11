using BusTickets.Data;
using BusTickets.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace BusTickets.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly BusTicketsContext context;

        public DatabaseService(BusTicketsContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.EnsureDeleted();
            this.context.Database.Migrate();

            Console.WriteLine("Database is initialized!");

            //DbInitializer.Seed(this.context);
        }
    }
}