using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRWebApp.Models;

namespace HRWebApp.Data
{
    public class JobRepository
    {
        private static List<Job> _jobs;

        static JobRepository()
        {
            _jobs = new List<Job>
            {
                new Job()
                {
                    JobTitle = "Junior Developer",
                    JobDescription = "Develops software solutions to meet customer requirements through team and individual efforts. Participates in the analysis and composition of requirements, design of architectural and component software features, design and implementation of system, design and implementation of test plan, and documentation of final product.",
                    JobRequirement = "Strong technical skills including understanding of software development principles. Atleast 1 year of experience in the field.",
                    JobId = 1
                },
                new Job()
                {
                    JobTitle = "Mid-Level Developer",
                    JobDescription = "Should be able to adapt to new languages, methodologies, and platforms to meet the needs of the project. Develop applications written in php, JavaScript, Perl, C++, C#, or Java. Initial duties may include reviewing code, writing documentation, and following test procedures.",
                    JobRequirement = "Object oriented programming, with base SW languages C++ and Java required; desired tool experience with ellipse and visual studio. Atleast 3.5 years of exerience in the field.",
                    JobId = 2
                }
            };
        }

        public IEnumerable<Job> GetAll()
        {
            return _jobs;
        }

        public Job Get(int jobId)
        {
            return _jobs.FirstOrDefault(j => j.JobId == jobId);
        }

        public void Add(Job job)
        {     
            var newJob = new Job();      
            newJob.JobTitle = job.JobTitle;
            newJob.JobDescription = job.JobDescription;
            newJob.JobRequirement = job.JobRequirement;
             
            newJob.JobId = _jobs.Max(c => c.JobId) + 1;

            _jobs.Add(newJob);
        }

        public void Edit(Job job)
        {
            var selectedJob = _jobs.First(c => c.JobId == job.JobId);

            selectedJob.JobTitle = job.JobTitle;
            selectedJob.JobDescription = job.JobDescription;
            selectedJob.JobRequirement = job.JobRequirement;
        }

        public void Delete(int jobId)
        {
            _jobs.RemoveAll(c => c.JobId == jobId);
        }

    }
}
