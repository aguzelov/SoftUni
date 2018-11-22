using Eventures.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            return app;
        }
    }
}