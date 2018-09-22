using HTTPServer.ByTheCakeApp.Controllers;
using HTTPServer.Server.Contracts;
using HTTPServer.Server.Routing.Contracts;

namespace HTTPServer.ByTheCakeApp
{
    public class ByTheCakeApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/", req => new HomeController(req).Index());

            appRouteConfig
                .Get("/about", req => new HomeController(req).About());

            appRouteConfig
                .Get("/add", req => new CakesController(req).Add());

            appRouteConfig
                .Post("/add", req => new CakesController(req).Add());

            appRouteConfig
                .Get("/search", req => new CakesController(req).Search());

            appRouteConfig
                .Get("/login", req => new AccountController(req).Login());

            appRouteConfig
                .Post("/login", req => new AccountController(req).Login());

            appRouteConfig
                .Post("/logout", req => new AccountController(req).Logout());

            appRouteConfig
                .Get(
                    "/shopping/add/{(?<id>[0-9]+)}",
                    req => new ShoppingController(req).AddToCart());

            appRouteConfig
                .Get(
                    "/cart",
                    req => new ShoppingController(req).ShowCart());

            appRouteConfig
                .Post(
                    "/shopping/finish-order",
                    req => new ShoppingController(req).FinishOrder());
        }
    }
}