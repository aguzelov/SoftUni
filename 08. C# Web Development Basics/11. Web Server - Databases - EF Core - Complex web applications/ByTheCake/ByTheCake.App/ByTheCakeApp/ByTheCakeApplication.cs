using ByTheCake.Data;
using HTTPServer.ByTheCakeApp.Controllers;
using HTTPServer.Server.Contracts;
using HTTPServer.Server.Routing.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HTTPServer.ByTheCakeApp
{
    public class ByTheCakeApplication : IApplication
    {
        private readonly ByTheCakeContext context;

        public ByTheCakeApplication(ByTheCakeContext context)
        {
            this.context = context;
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            MigrateDb();
            RouteConfig(appRouteConfig, this.context);
        }

        private void MigrateDb()
        {
            this.context.Database.Migrate();
        }

        private static void RouteConfig(IAppRouteConfig appRouteConfig, ByTheCakeContext context)
        {
            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new CakesController(context).Add());

            appRouteConfig
                .Post("/add", req => new CakesController(context).Add(req));

            appRouteConfig
                .Get(
                    "/cakeDetails/{(?<id>[0-9]+)}",
                    req => new CakesController(context).Details(req));

            appRouteConfig
                .Get("/search", req => new CakesController(context).Search(req));

            appRouteConfig
                .Get("/login", req => new AccountController(context).Login());

            appRouteConfig
                .Post("/login", req => new AccountController(context).Login(req));

            appRouteConfig
                .Post("/logout", req => new AccountController(context).Logout(req));

            appRouteConfig
                .Get("/register", req => new AccountController(context).Register());

            appRouteConfig
                .Post("/register", req => new AccountController(context).Register(req));

            appRouteConfig
                .Get("/profile", req => new AccountController(context).Profile(req));

            appRouteConfig
                .Get("/orders", req => new AccountController(context).Orders(req));

            appRouteConfig
                .Get("/orderDetails/{(?<id>[0-9]+)}", req => new AccountController(context).OrderDetails(req));

            appRouteConfig
                .Get(
                    "/shopping/add/{(?<id>[0-9]+)}",
                    req => new ShoppingController(context).AddToCart(req));

            appRouteConfig
                .Get(
                    "/cart",
                    req => new ShoppingController(context).ShowCart(req));

            appRouteConfig
                .Post(
                    "/shopping/finish-order",
                    req => new ShoppingController(context).FinishOrder(req));
        }
    }
}