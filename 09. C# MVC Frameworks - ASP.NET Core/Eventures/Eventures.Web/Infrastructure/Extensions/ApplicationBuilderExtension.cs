using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventures.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.Migrate();
                SeedEvents(db);
                AddRoles(serviceScope, db);
            }

            return app;
        }

        private static void SeedEvents(ApplicationDbContext db)
        {
            //if (db.Events.Any())
            //{
            //    return;
            //}

            var events = new List<Event>();

            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                var start = DateTime.UtcNow.AddDays(random.Next(10, 100) * -1);

                var @event = new Event
                {
                    Name = $"Event Name {i}",
                    Place = $"Event Place {i}",
                    TotalTickets = random.Next(10, 10000),
                    PricePerTicket = random.Next(10, 1000),
                    Start = start,
                    End = start.AddDays(random.Next(1, 10))
                };

                events.Add(@event);

                events.Add(@event);
            }

            db.Events.AddRange(events);
            db.SaveChanges();
        }

        private static void AddRoles(IServiceScope serviceScope, ApplicationDbContext db)
        {
            if (!db.Roles.AnyAsync().Result)
            {
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var adminRole = GlobalConstants.AdminRole;
                    var userRole = GlobalConstants.UserRole;

                    await roleManager.CreateAsync(new IdentityRole
                    {
                        Name = adminRole
                    });

                    await roleManager.CreateAsync(new IdentityRole
                    {
                        Name = userRole
                    });
                }).Wait();
            }
        }
    }
}