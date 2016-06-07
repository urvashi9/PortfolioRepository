using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRWebApp.Models;

namespace HRWebApp.Data
{
    public class ApplicationRepository
    {
        private static List<Application> _applications;

        static ApplicationRepository()
        {
            _applications = new List<Application>
            {
                new Application
                {
                    ApplicationId = 1,
                    Name = "John Doe",
                    Address = new Address()
                    {
                        Street1 = "526 S Main Street",
                        City = "Akron",
                        State = "Ohio",
                        Zipcode = "44133"
                    },
                    PhoneNumber = "123-123-1231",
                    Dob = new DateTime(1988,05,12),
                    EmailId = "johndoe@gmail.com",
                    Education = new List<Education>()
                    {
                        new Education()
                        {
                            Degree = "MS",
                            GraduationYear = new DateTime(2010,05,20),
                            Major = "Computer Science",
                            School = "Ohio State University"
                        }
                        
                    },
                    SkillSet = "Java, C#, VB, HTML, CSS",
                    WorkHistory = new List<WorkHistory>()
                    {
                        new WorkHistory()
                        {
                            CompanyName = "ABCD Corp",
                            JobTitle = "Junior Developer",
                            Years = 1.5m
                        }
                        
                    },
                    BriefDescription = "I want the job.",
                    JobApplyingFor = new Job()
                    {
                        JobTitle = "Mid-Level Software Developer"
                    }
                },
                new Application()
                {
                    ApplicationId = 2,
                    Name = "Jane Doe",
                    Address = new Address()
                    {
                        Street1 = "3788 Dearborn Street",
                        City = "Rochester Hills",
                        State = "Michigan",
                        Zipcode = "48309"
                    },
                    PhoneNumber = "456-456-4564",
                    Dob = new DateTime(1987,10,22),
                    EmailId = "janedoe@gmail.com",
                    Education = new List<Education>()
                    {
                        new Education()
                        {
                            Degree = "MS",
                            GraduationYear = new DateTime(2010,05,20),
                            Major = "Software Engineering",
                            School = "University of Michigan"
                        }
                    },
                    SkillSet = "C#, VB, HTML, CSS, PHP, JavaScript",
                    WorkHistory = new List<WorkHistory>()
                    {
                        new WorkHistory()
                        {
                            CompanyName = "EFGH Corp",
                            JobTitle = "Software Engineer",
                            Years = 2.5m
                        }
                    },
                    BriefDescription = "I want the job.",
                    JobApplyingFor = new Job()
                    {
                        JobTitle = "Mid-Level Software Developer"
                    }
                }
            };
        }

        public IEnumerable<Application> GetAll()
        {
            return _applications;
        }

        public Application Get(int applicationId)
        {
            return _applications.FirstOrDefault(a => a.ApplicationId == applicationId);
        }

        public void Add(Application application)
        {
            application.ApplicationId = _applications.Max(a => a.ApplicationId) + 1;
            _applications.Add(application);

        }


    }
}
