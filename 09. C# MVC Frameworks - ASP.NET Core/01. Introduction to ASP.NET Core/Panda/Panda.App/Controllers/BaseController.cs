using Microsoft.AspNetCore.Mvc;
using Panda.Services.Contracts;

namespace Panda.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IAccountService accountService;

        protected BaseController(IAccountService accountService)
            : base()
        {
            this.accountService = accountService;
        }
    }
}