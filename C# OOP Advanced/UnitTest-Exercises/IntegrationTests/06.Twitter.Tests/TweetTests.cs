using System;
using Moq;
using NUnit.Framework;

namespace _06.Twitter.Tests
{
    [TestFixture]
    public class TweetTests
    {
        private Mock<IClient> client;
        private ITweet tweet;
        [SetUp]
        public void InitializeMockTweet()
        {
             client = new Mock<IClient>();
            this.client.Setup(c => c.WriteTweet(It.IsAny<string>()));
            this.tweet = new Tweet(client.Object);
        }

        [Test]
        public void ReceiveMessageShouldInvokeItsClientToWriteTheMessage()
        { 
            tweet.ReceiveMessage("test");

            client.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ReceiveMessageShouldInvokeItsClientToSendTheMessageToTheServer()
        {
            tweet.ReceiveMessage("test");

            client.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once);
        }
    }
}
