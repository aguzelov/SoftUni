using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface ITownService
    {
        Town AddTown(string townName, string countryName);

        bool Exist(string townName);
    }
}