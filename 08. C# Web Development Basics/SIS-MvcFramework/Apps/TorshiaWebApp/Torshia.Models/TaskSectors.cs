namespace Torshia.Models
{
    public class TaskSectors
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public virtual Task Task { get; set; }

        public Sector Sector { get; set; }
    }
}