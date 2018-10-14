using SIS.Framework.ActionResult.Contracts;

namespace SIS.Framework.ActionResult
{
    public class RedirectResult : IRedirectable
    {
        public RedirectResult(string redirectUrl)
        {
            this.RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; }

        public string Invoke() => this.RedirectUrl;
    }
}