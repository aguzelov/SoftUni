using TeamBuilder.Models;

namespace TeamBuilder.Services.Contracts
{
    public interface IEventService
    {
        void AddEvent(Event @event);

        Event GetEvent(string eventName);

        TModel[] GetAllEvents<TModel>(string eventName);

        bool IsEventExisting(string eventName);
    }
}