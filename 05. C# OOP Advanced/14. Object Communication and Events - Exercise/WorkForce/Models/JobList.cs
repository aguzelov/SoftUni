using System.Collections.Generic;

namespace WorkForce.Models
{
    public class JobList : List<Job>
    {
        public void AddJob(Job job)
        {
            this.Add(job);
            job.JobComplete += this.OnJobComplete;
        }

        public void OnJobComplete(Job job)
        {
            this.Remove(job);
        }
    }
}