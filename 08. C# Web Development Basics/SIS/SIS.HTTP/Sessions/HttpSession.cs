using SIS.HTTP.Sessions.Contracts;
using System.Collections.Generic;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> _sessionParametes;

        public HttpSession(string id)
        {
            this.Id = id;

            this._sessionParametes = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            if (!this._sessionParametes.ContainsKey(name))
            {
                this._sessionParametes.Add(name, null);
            }

            this._sessionParametes[name] = parameter;
        }

        public void ClearParametes()
        {
            this._sessionParametes.Clear();
        }

        public bool ContainsParameter(string name)
        {
            var isContains = this._sessionParametes.ContainsKey(name);

            return isContains;
        }

        public object GetParameter(string name)
        {
            if (!ContainsParameter(name))
            {
                return null;
            }

            var parameter = this._sessionParametes[name];

            return parameter;
        }
    }
}