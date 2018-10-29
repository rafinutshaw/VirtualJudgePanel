using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJP_Entity;
using VJP_Interface;
using VJP_Repository;

namespace VJP_App.Controllers
{
    public class SignUpController : Controller
    {
        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IStudentRepository studentRepository;
        public SignUpController(IAccountTypeRepository accountTypeRepository,
            IUserRepository userRepository, IStudentRepository studentRepository)
        {
            this.accountTypeRepository = accountTypeRepository;
            this.userRepository = userRepository;
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.AccountyType_Id = new SelectList(accountTypeRepository.GetAll(), "Id", "Type");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var check = userRepository.DuplicateEmail(user.Email);
                if (check)
                {
                    ViewBag.Avalilabe = "Email is already registerd!";
                    return View();
                }
                else
                {
                    user.AccountType_Id = 2;
                    user.CreateDate = DateTime.Now;

                    userRepository.Insert(user);

                    Student student = new Student
                    {
                        StudentId = user.Id
                    };
                    studentRepository.Insert(student);

                    Session["email"] = user.Email;
                    Session["userType"] = user.AccountType_Id;
                    Session["userTypeName"] = "Student";
                    Session["id"] = user.Id;

                    TempData["Create"] = "Thank you! " + user.Email + " for joining here. Please Login now!";

                    return RedirectToAction("Index", "Student");
                }
            }
            else
            {
                TempData["CreateFailed"] = "User creation failed";

                return View();
            }
        }
    }
}