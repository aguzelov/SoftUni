using System.Collections.Generic;

namespace Torshia.App.ViewModels
{
    public class TaskDetailView
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string DueDate { get; set; }

        public string ParticipantsAsString => string.Join(", ", this.Participants);

        public string Level { get; set; }

        public IEnumerable<string> Participants { get; set; }
    }
}