namespace Twitter.Contracts
{
    public interface IClient
    {
        void ReceiveTweet(ITweet tweet);

        void AddWriter(IWriter writer);
    }
}