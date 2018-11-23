using Eventures.Models;
using System.Collections.Generic;

namespace Eventures.Services.Contracts
{
    public interface IOrdersService
    {
        bool Create(User user, Event @event, int ticketsCount);

        ICollection<T> All<T>();

        ICollection<T> AllByUser<T>(string username);
    }
}