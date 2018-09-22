using System;
using System.Net;

namespace ValidateURL
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var encodedURL = Console.ReadLine();

            var decodedURL = WebUtility.UrlDecode(encodedURL);

            try
            {
                var uri = new Uri(decodedURL);
                var isValid = ValidateURLParts(uri);
                if (!isValid)
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }

                PrintURLParts(uri);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid URL");
            }
        }

        private static bool ValidateURLParts(Uri uri)
        {
            if (string.IsNullOrEmpty(uri.Scheme) ||
                string.IsNullOrEmpty(uri.Host) ||
                string.IsNullOrEmpty(uri.Port.ToString()) ||
                string.IsNullOrEmpty(uri.AbsolutePath) ||
                (uri.Scheme == "http" && uri.Port == 443) ||
                (uri.Scheme == "https" && uri.Port == 80))
            {
                return false;
            }

            return true;
        }

        private static void PrintURLParts(Uri uri)
        {
            var protocol = uri.Scheme;
            var host = uri.Host;
            var port = uri.Port;
            var path = uri.AbsolutePath;
            var query = uri.Query;
            var fragment = uri.Fragment;

            Console.WriteLine("Protocol: " + protocol);
            Console.WriteLine("Host: " + host);
            Console.WriteLine("Part: " + port);
            Console.WriteLine("Path: " + path);

            query = query.Remove(0, 1);
            if (!string.IsNullOrEmpty(query))
            {
                Console.WriteLine("Query: " + query);
            }

            fragment = fragment.Remove(0, 1);
            if (!string.IsNullOrEmpty(fragment))
            {
                Console.WriteLine("Fragment: " + fragment);
            }
        }
    }
}