﻿namespace HTTPServer.Server.Http.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        object Get(string key);

        T Get<T>(string key);

        void Add(string key, object value);

        void Clear();

        bool HasSessions { get; }

        bool Contains(string key);
    }
}