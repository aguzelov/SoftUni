using System;
using Moq;
using NUnit.Framework;
using Twitter.Contracts;
using Twitter.IO;
using Twitter.Models;

namespace Twitter.Tests
{
    [TestFixture]
    public class ClientTests
    {
        private const string TestMessage = "Test";
        private Client client;

        [Test]
        public void RecieveWriterInConstructor()
        {
            // Arraneg
            IWriter writer = new ConsoleWriter();

            // Act
            client = new Client(writer);

            // Assert
            Assert.AreEqual(1, this.client.Writers.Count);
        }

        [Test]
        public void AddNewWriter()
        {
            // Arraneg
            IWriter writer = new ConsoleWriter();
            client = new Client(writer);
            IWriter secondWriter = new ServerWriter();

            // Act
            this.client.AddWriter(secondWriter);

            // Assert
            Assert.AreEqual(2, this.client.Writers.Count);
        }

        [Test]
        public void RecievTweet()
        {
            // Arraneg
            IWriter writer = new ConsoleWriter();
            client = new Client(writer);
            ITweet tweet = new Tweet()
            {
                Message = TestMessage
            };

            // Act
            this.client.AddWriter(writer);
            this.client.ReceiveTweet(tweet);

            // Assert
            Assert.AreEqual(tweet.Message, this.client.Tweet.Message);
        }

        [Test]
        public void RecievNullTweet()
        {
            // Arraneg
            IWriter writer = new ConsoleWriter();
            client = new Client(writer);
            ITweet tweet = null;

            // Act
            this.client.AddWriter(writer);

            // Assert
            Assert.Throws<ArgumentNullException>(() => this.client.ReceiveTweet(tweet));
        }
    }
}