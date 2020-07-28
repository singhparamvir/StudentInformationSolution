using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentInformation.DataAccess.StudentAccount;
using StudentInformation.Web.Models;
using StudentInformation.BusinessLogic.Student;
namespace StudentInformation.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET All Students
        //For now just getting all the student it should be done based on pagination
        //Not all student at same time
        public ActionResult Index()
        {
            var studentViewModel = new StudentModel();
            ModelState.Clear();
            return View("Index", studentViewModel.GetAllStudent());
        }

       
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel sModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentModel = new StudentModel();
                    if (studentModel.AddStudent(sModel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "Exception occured" + ex;
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var studentModel = new StudentModel();
            return View(studentModel.GetStudentById(id).First());
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var studentModel = new StudentModel();
                if (studentModel.DeleteRegisteredStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
