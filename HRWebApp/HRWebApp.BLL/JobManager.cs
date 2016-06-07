using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRWebApp.Data;
using HRWebApp.Models;

namespace HRWebApp.BLL
{
    public class JobManager
    {
        private JobRepository repo = new JobRepository();
        public IEnumerable<Job> GetAllJobs()
        {
            return repo.GetAll();
        }

        public Job GetJob(int id)
        {
            return repo.Get(id);
        }

        public void AddJob(Job job)
        {
            repo.Add(job);
        }

        public void EditJob(Job job)
        {
           repo.Edit(job);
        }

        public void DeleteJob(Job job)
        {
            repo.Delete(job.JobId);
        }
    }
}
