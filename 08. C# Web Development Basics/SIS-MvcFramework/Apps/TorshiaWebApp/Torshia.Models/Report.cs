using System;

namespace Torshia.Models
{
    public class Report
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime ReporterdOn { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int UserId { get; set; }
        public virtual User Reporter { get; set; }
    }
}