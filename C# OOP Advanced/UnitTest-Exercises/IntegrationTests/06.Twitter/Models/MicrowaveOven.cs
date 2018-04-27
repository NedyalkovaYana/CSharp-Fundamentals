public class MicrowaveOven : IClient
{
    private IWriter writer;
    private ITweetRepository repository;

    public MicrowaveOven(IWriter writer, ITweetRepository repository)
    {
        this.writer = writer;
        this.repository = repository;
    }

    public void WriteTweet(string message)
    {
        this.writer.WriteLine(message);
    }

    public void SendTweetToServer(string message)
    {
        this.repository.SaveTweet(message);
    }
}

