using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRWebApp.BLL;
using HRWebApp.Models;

namespace HRWebAppUI.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Jobs()
        {
            var manager = new JobManager();
            var model = manager.GetAllJobs();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddJob()
        {
            return View(new Job());
        }

        [HttpPost]
        public ActionResult AddJob(Job job)
        {
            var manager = new JobManager();
            manager.AddJob(job);
            return RedirectToAction("Jobs");
        }

        [HttpGet]
        public ActionResult EditJob(int id)
        {
            var manager = new JobManager();
            var model = manager.GetJob(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditJob(Job job)
        {
            var manager = new JobManager();
            manager.EditJob(job);
            return RedirectToAction("Jobs");
        }

        [HttpGet]
        public ActionResult DeleteJob(int id)
        {
            var manager = new JobManager();
            var model = manager.GetJob(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteJob(Job job)
        {
            var manager = new JobManager();
            manager.DeleteJob(job);
            return RedirectToAction("Jobs");
        }

        [HttpGet]
        public ActionResult Applications()
        {
            var manager = new ApplicationManager();
            var model = manager.GetAllApplications();
            return View(model.ToList());
        } 

        [HttpGet]
        public ActionResult SingleApplication(int id)
        {
            var manager = new ApplicationManager();
            var application = manager.GetApplication(id);
            return View(application);
        }
    }
}