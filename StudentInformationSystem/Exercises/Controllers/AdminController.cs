using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        private MajorRepository majorRepo = new MajorRepository();
        private StateRepository stateRepo = new StateRepository();
        [HttpGet]
        public ActionResult Majors()
        {
            var model = majorRepo.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            majorRepo.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = majorRepo.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            majorRepo.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = majorRepo.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            majorRepo.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = stateRepo.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            stateRepo.Add(state);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult EditState(int id)
        {
            var state = stateRepo.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            stateRepo.Edit(state);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteState(int id)
        {
            var state = stateRepo.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            stateRepo.Delete(state.StateId);
            return RedirectToAction("States");
        }
    }
}