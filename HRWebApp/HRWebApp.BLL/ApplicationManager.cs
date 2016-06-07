using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRWebApp.Data;
using HRWebApp.Models;

namespace HRWebApp.BLL
{
    public class ApplicationManager
    {
        private ApplicationRepository repo = new ApplicationRepository();
        public IEnumerable<Application> GetAllApplications()
        {           
            return repo.GetAll();
        }

        public Application GetApplication(int id)
        {
            return repo.Get(id);
        }

        public void AddApplication(Application application)
        {
            repo.Add(application);
        }
    }
}