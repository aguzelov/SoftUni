﻿using CakesWebApp.ViewModels.User;
using SIS.HTTP.Responses;
using System.Linq;

namespace CakesWebApp.Controllers
{
    public class UserController : BaseController
    {
        public IHttpResponse Profile()
        {
            var viewModel = this.Db.Users.Where(x => x.Username == this.User.Username)
                .Select(x => new ProfileViewModel
                {
                    Username = x.Username,
                    RegisteredOn = x.DateOfRegistration,
                    OrdersCount = x.Orders.Count(),
                }).FirstOrDefault();

            if (viewModel == null)
            {
                return this.BadRequestError("Profile page not accessible for this user.");
            }

            if (viewModel.OrdersCount > 0)
            {
                viewModel.OrdersCount--;
            }

            return this.View(viewModel);
        }
    }
}