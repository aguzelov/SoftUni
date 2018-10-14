using SIS.HTTP.Sessions.Contracts;
using System.Collections.Concurrent;

namespace SIS.HTTP.Sessions
{
    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";
        public const string SessionStoreKey = "SIS_STORE_ID";

        private static readonly ConcurrentDictionary<string, IHttpSession> Sessions
            = new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return Sessions.GetOrAdd(id, _ => new HttpSession(id));
        }
    }
}