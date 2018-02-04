// https://msdn.microsoft.com/en-gb/library/system.net.httplistener.aspx

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;

public class HTTPServer
{
    public static void Main()
    {
        WebServer ws = new WebServer(SendResponse, "http://localhost:8081/");
        ws.Run();
        Console.WriteLine("A simple webserver start on http://localhost:8081. Press a key to quit.");
        Console.ReadKey();
        ws.Stop();
    }

    public static string SendResponse(HttpListenerRequest request)
    {
        string url = request.Url.ToString();

        int lastIndexOfSlash = url.LastIndexOf('/');
        string resource = url.Substring(lastIndexOfSlash + 1);
        if (lastIndexOfSlash == url.Length - 1 || resource == "index")
        {
            return ReadFile("index.html");
        }
        else if (resource == "info")
        {
            string infoPage = ReadFile("info.html");

            string date = DateTime.Now.ToString("dd MMM yyyy hh:mm:ss", CultureInfo.InvariantCulture);

            infoPage = infoPage.Replace("{0}", date);
            infoPage = infoPage.Replace("{1}", Environment.ProcessorCount.ToString());
            return infoPage;
        }
        else
        {
            return ReadFile("error.html");
        }
    }

    private static string ReadFile(string file)
    {
        string allLines = "";
        using (var reader = new StreamReader(file))
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                allLines += line;
            }
        }

        return allLines;
    }
}

public class WebServer
{
    private readonly HttpListener _listener = new HttpListener();
    private readonly Func<HttpListenerRequest, string> _responderMethod;

    public WebServer(string[] prefixes, Func<HttpListenerRequest, string> method)
    {
        if (!HttpListener.IsSupported)
            throw new NotSupportedException(
                "Needs Windows XP SP2, Server 2003 or later.");

        // URI prefixes are required, for example 
        // "http://localhost:8080/index/".
        if (prefixes == null || prefixes.Length == 0)
            throw new ArgumentException("prefixes");

        if (method == null)
            throw new ArgumentException("method");

        foreach (string s in prefixes)
            _listener.Prefixes.Add(s);

        _responderMethod = method;
        _listener.Start();
    }

    public WebServer(Func<HttpListenerRequest, string> method, params string[] prefixes)
        : this(prefixes, method) { }

    public void Run()
    {
        ThreadPool.QueueUserWorkItem((o) =>
        {
            Console.WriteLine("Webserver running...");
            try
            {
                while (_listener.IsListening)
                {
                    ThreadPool.QueueUserWorkItem((c) =>
                    {
                        var ctx = c as HttpListenerContext;
                        try
                        {
                            string rstr = _responderMethod(ctx.Request);
                            byte[] buf = Encoding.UTF8.GetBytes(rstr);
                            ctx.Response.ContentLength64 = buf.Length;
                            ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                        }
                        catch { }
                        finally
                        {
                            ctx.Response.OutputStream.Close();
                        }
                    }, _listener.GetContext());
                }
            }
            catch { }
        });
    }

    public void Stop()
    {
        _listener.Stop();
        _listener.Close();
    }
}
