﻿using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Contracts;

namespace SIS.App.IRunes.Services.UserCookieServices
{
    public interface IUserCookieService
    {
        HttpCookie GetUserCookie(string username);

        string GetUsername(IHttpCookieCollection cookies);
    }
}