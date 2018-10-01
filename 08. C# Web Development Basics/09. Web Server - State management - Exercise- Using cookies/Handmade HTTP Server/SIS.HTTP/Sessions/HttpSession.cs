using SIS.HTTP.Sessions.Contracts;
using System.Collections.Generic;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private Dictionary<string, object> sessionParametes;

        public HttpSession(string id)
        {
            this.Id = id;

            this.sessionParametes = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            if (!this.sessionParametes.ContainsKey(name))
            {
                this.sessionParametes.Add(name, null);
            }

            this.sessionParametes[name] = parameter;
        }

        public void ClearParametes()
        {
            this.sessionParametes.Clear();
        }

        public bool ContainsParameter(string name)
        {
            var isContains = this.sessionParametes.ContainsKey(name);

            return isContains;
        }

        public object GetParameter(string name)
        {
            if (!this.ContainsParameter(name))
            {
                return null;
            }

            var parameter = this.sessionParametes[name];

            return parameter;
        }
    }
}