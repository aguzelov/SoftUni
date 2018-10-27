using SIS.HTTP.Cookies;

namespace SIS.Framework.Services.UserCookieServices
{
    public interface IUserCookieService
    {
        HttpCookie GetUserCookie(string username);

        string GetUsername(IHttpCookieCollection cookies);
    }
}