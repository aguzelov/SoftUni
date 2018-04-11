using System;
using NUnit.Framework;
using Twitter.Models;

namespace Twitter.Tests
{
    [TestFixture]
    public class TweetTests
    {
        private const string MessageToAdd = "Some creative message";
        private Tweet tweet;

        [SetUp]
        public void InitTest()
        {
            this.tweet = new Tweet();
        }

        [Test]
        public void AddMessageToTweet()
        {
            //Arrange

            //Act
            this.tweet.Message = MessageToAdd;

            //Assert
            Assert.AreEqual(MessageToAdd, this.tweet.Message);
        }

        [Test]
        public void AddNullMessageToTweet()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => this.tweet.Message = null);
        }
    }
}