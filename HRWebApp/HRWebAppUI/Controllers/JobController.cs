using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRWebApp.BLL;
using HRWebApp.Models;

namespace HRWebAppUI.Controllers
{
    public class JobController : Controller
    {
        [HttpGet]
        public ActionResult Jobs()
        {
            var manager = new JobManager();
            var model = manager.GetAllJobs();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddApplication(int id)
        {
            var application = new Application();
            var jobManager = new JobManager();
            application.JobApplyingFor = jobManager.GetJob(id);
            return View(application);
        }

        [HttpPost]
        public ActionResult AddApplication(Application application)
        {
            var manager = new ApplicationManager();            
            if (ModelState.IsValid)
            {
                manager.AddApplication(application);
                return RedirectToAction("Jobs");
            }           
            return AddApplication(application.ApplicationId);
        }
    }
}