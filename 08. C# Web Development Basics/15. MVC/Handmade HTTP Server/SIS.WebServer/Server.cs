using SIS.WebServer.Api;
using SIS.WebServer.Routing;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalhostIpAddress = "127.0.0.1";

        private readonly int _port;

        private readonly TcpListener _listener;

        private readonly ServerRoutingTable _serverRoutingTable;
        private readonly IHandleable handler;

        public bool IsRunning;

        public Server(int port)
        {
            this._port = port;
            this._listener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), this._port);
        }

        public Server(int port, ServerRoutingTable serverRoutingTable)
            : this(port)
        {
            this._serverRoutingTable = serverRoutingTable;
        }

        public Server(int port, IHandleable handler)
            : this(port)
        {
            this.handler = handler;
        }

        public void Run()
        {
            this._listener.Start();
            this.IsRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this._port}");

            var task = Task.Run(ListenLoop);
            task.Wait();
        }

        public async Task ListenLoop()
        {
            while (this.IsRunning)
            {
                var client = await this._listener.AcceptSocketAsync();

                ConnectionHandler connectionHandler = null;

                if (this.handler == null)
                {
                    connectionHandler = new ConnectionHandler(client, this._serverRoutingTable);
                }
                else
                {
                    connectionHandler = new ConnectionHandler(client, this.handler);
                }

                var responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
            }
        }
    }
}