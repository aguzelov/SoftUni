using System;
using System.Net;

namespace URLDecode
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var encodedUrl = Console.ReadLine();

            var decodedUrl = WebUtility.UrlDecode(encodedUrl);

            Console.WriteLine(decodedUrl);
        }
    }
}