using System.Collections.Generic;

namespace Panda.Services.Contracts
{
    public interface IReceiptsService
    {
        ICollection<T> GetUserReceipts<T>(string username);

        T Details<T>(string id);
    }
}