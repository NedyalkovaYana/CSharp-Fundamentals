 using Moq;
 using NUnit.Framework;

[TestFixture]
public class ClientTests
{
    private const string Messsage = "Test";
    private Mock<IWriter> writer;
    private Mock<ITweetRepository> repository;
    private IClient microwaveOven;

    [SetUp]
    public void InitializeMockClient()
    {
        this.writer = new Mock<IWriter>();
        this.repository = new Mock<ITweetRepository>();
        this.repository.Setup(r => r.SaveTweet(It.IsAny<string>()));
        this.microwaveOven = new MicrowaveOven(writer.Object, repository.Object);
    }

    [Test]
    public void SendTweetToServerShouldSendTheMessageToItsServer()
    {
        microwaveOven.SendTweetToServer(Messsage);

        repository.Verify(r => r.SaveTweet
        (It.Is<string>(s => s == Messsage)), Times.Once);
    }

    [Test]
    public void WriteTweetShouldCallItsWriterWithTheTweetsMessage()
    {
        microwaveOven.WriteTweet(Messsage);

        writer.Verify(w => w.WriteLine(It.Is<string>(s => s == Messsage)));
    }
}

