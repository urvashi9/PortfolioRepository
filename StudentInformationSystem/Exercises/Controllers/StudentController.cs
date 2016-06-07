using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        private MajorRepository majorRepo = new MajorRepository();
        private CourseRepository courseRepo = new CourseRepository();
        private StudentRepository studentRepo = new StudentRepository();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = studentRepo.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {          
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(courseRepo.GetAll());
            viewModel.SetMajorItems(majorRepo.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();
            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(courseRepo.Get(id));

            studentVM.Student.Major = majorRepo.Get(studentVM.Student.Major.MajorId);

            studentRepo.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = studentRepo.Get(id);
            var viewModel = new StudentVM();
            viewModel.Student = student;
            viewModel.SetCourseItems(courseRepo.GetAll());
            if (student.Courses!=null)
            {
                foreach (var course in student.Courses)
                {
                    viewModel.SelectedCourseIds.Add(course.CourseId);
                }
            }          
            viewModel.SetMajorItems(majorRepo.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(courseRepo.Get(id));

            studentVM.Student.Major = majorRepo.Get(studentVM.Student.Major.MajorId);

            studentRepo.Edit(studentVM.Student);

            return RedirectToAction("List");            
        }

        [HttpGet]
        public ActionResult EditAddress(int id)
        {
            var student = studentRepo.Get(id);
            var viewModel = new StudentVM();
            viewModel.Student.Address = student.Address;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditAddress(StudentVM studentVM)
        {
            //studentVM.Student = StudentRepository.Get(studentVM.Student.StudentId);
            studentRepo.EditAddress(studentVM.Student);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = studentRepo.Get(id);           
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            
            studentRepo.Delete(student.StudentId);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult BindAddress()
        {
            return View(new Student() {Address = new Address()});
        }
    }
}