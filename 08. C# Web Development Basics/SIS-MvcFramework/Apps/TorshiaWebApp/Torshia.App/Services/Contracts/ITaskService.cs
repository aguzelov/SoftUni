using Torshia.App.ViewModels;
using Torshia.Models;

namespace Torshia.App.Services.Contracts
{
    public interface ITaskService
    {
        Task AddTask(CreateTaskView view);

        Task GetTask(int id);
    }
}