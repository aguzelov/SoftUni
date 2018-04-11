using Twitter.Contracts;
using Twitter.IO;
using Twitter.Models;

namespace Twitter
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ITweet tweet = new Tweet()
            {
                Message = "DuraBura"
            };

            IWriter consoleWriter = new ConsoleWriter();
            IWriter serverWriter = new ServerWriter();

            IClient client = new Client(consoleWriter, serverWriter);

            client.ReceiveTweet(tweet);
        }
    }
}