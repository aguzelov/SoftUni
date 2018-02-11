namespace TODOList.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TaskDbContext : DbContext
    {
        
        public TaskDbContext()
            : base("name=TaskDbContext")
        {
        }
        
         public virtual DbSet<Task> Tasks { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}