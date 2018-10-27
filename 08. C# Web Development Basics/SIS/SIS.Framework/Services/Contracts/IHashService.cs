namespace IRunes.Services.PasswordServices
{
    public interface IHashService
    {
        string GenerateHash(string plainText);
    }
}