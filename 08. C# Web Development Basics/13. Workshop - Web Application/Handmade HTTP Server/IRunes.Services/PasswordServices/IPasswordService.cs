namespace IRunes.Services.PasswordServices
{
    public interface IPasswordService
    {
        string GenerateHash(string plainText);
    }
}