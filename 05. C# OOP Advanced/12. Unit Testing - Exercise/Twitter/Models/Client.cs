using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Contracts;

namespace Twitter.Models
{
    public class Client : IClient
    {
        private ITweet tweet;
        private List<IWriter> writers;

        public Client(params IWriter[] writers)
        {
            this.writers = new List<IWriter>(writers);
        }

        public IReadOnlyCollection<IWriter> Writers
        {
            get
            {
                return this.writers;
            }
        }

        public ITweet Tweet => this.tweet;

        public void AddWriter(IWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException();
            }
            this.writers.Add(writer);
        }

        public void ReceiveTweet(ITweet tweet)
        {
            this.tweet = tweet ?? throw new ArgumentNullException("Tweet can`t be null!");

            this.SendToWriter();
        }

        private void SendToWriter()
        {
            this.writers.ForEach(w => w.WriteMessage(this.tweet.Message));
        }
    }
}