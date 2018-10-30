using System;
using System.Collections.Generic;
using System.Linq;
using Torshia.App.Services.Contracts;
using Torshia.App.ViewModels;
using Torshia.Data;
using Torshia.Models;

namespace Torshia.App.Services
{
    public class TaskService : ITaskService
    {
        private readonly TorshiaCotnext cotnext;

        public TaskService(TorshiaCotnext cotnext)
        {
            this.cotnext = cotnext;
        }

        public Task AddTask(CreateTaskView view)
        {
            if (!Validate(view))
            {
                return null;
            }

            var participants = this.cotnext.Users
                .Where(u => view.Participants().Contains(u.Username))
                .ToList();

            if (participants.Count != view.Participants().Count)
            {
                return null;
            }

            var taskUsers = new List<TaskUsers>();
            foreach (var user in participants)
            {
                taskUsers.Add(new TaskUsers
                {
                    UserId = user.Id
                });
            }

            var sectors = view.Sectors().Select(s => Enum.Parse<Sector>(s));

            var taskSectors = new List<TaskSectors>();
            foreach (var sector in sectors)
            {
                taskSectors.Add(new TaskSectors
                {
                    Sector = sector
                });
            }

            var task = new Task
            {
                Title = view.Title,
                DueDate = view.DueDate,
                Description = view.Description,
                Participants = taskUsers,
                AffectedSectors = taskSectors
            };
            this.cotnext.Tasks.Add(task);

            this.cotnext.SaveChanges();

            return task;
        }

        public Task GetTask(int id)
        {
            var task = this.cotnext.Tasks.Find(id);

            return task;
        }

        private bool Validate(CreateTaskView view)
        {
            return view.Title != null ||
                view.DueDate != null ||
                view.Description != null ||
                view.Participants().Count != 0 ||
                view.Sectors().Count != 0;
        }
    }
}