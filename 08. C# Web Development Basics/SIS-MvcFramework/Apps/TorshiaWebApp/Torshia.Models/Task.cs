using System;
using System.Collections.Generic;

namespace Torshia.Models
{
    public class Task
    {
        public Task()
        {
            this.Reports = new HashSet<Report>();
            this.Participants = new HashSet<TaskUsers>();
            this.AffectedSectors = new HashSet<TaskSectors>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public virtual ICollection<TaskUsers> Participants { get; set; }

        public virtual ICollection<TaskSectors> AffectedSectors { get; set; }
    }
}