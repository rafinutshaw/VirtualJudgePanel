using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJP_Interface;
using VJP_Entity;

namespace VJP_App.Controllers
{
    public class StudentController : Controller
    {
        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;

        public StudentController
            (
            IAccountTypeRepository accountTypeRepository,
            IUserRepository userRepository, 
            IEventRepository eventRepository,
            IEventCategoryRepository eventCategoryRepository, 
            IStudentRepository studentRepository,
            IJudgeRepository judgeRepository, 
            IOrganizationRepository organizationRepository
            )
        {
            this.accountTypeRepository = accountTypeRepository;
            this.userRepository = userRepository;
            this.eventRepository = eventRepository;
            this.eventCategoryRepository = eventCategoryRepository;
            this.studentRepository = studentRepository;
            this.judgeRepository = judgeRepository;
            this.organizationRepository = organizationRepository;
        }


        // GET: Student
        public ActionResult Index()
        {
            if (Session["email"] != null && Session["userType"].ToString() == "2")
            {
                ViewBag.Event = eventRepository.GetAll();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(studentRepository.Get(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Student Student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Update(Student);

                TempData["Edited"] = "Account Type Edited.";

                return RedirectToAction("Edit", new { id = Session["id"] });
            }
            else
            {
                TempData["EditFailed"] = "Error occurs.";

                return View(Student);
            }
        }
        
        [HttpGet]
        public ActionResult Account(int id)
        {
            return View(userRepository.Get(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Account(string CurrentPassword, string Password, string ConfirmPassword)
        {
            if (Password == ConfirmPassword)
            {
                User user = userRepository.Get(Convert.ToInt32(Session["id"]));
                if (CurrentPassword == user.Password)
                {
                    user.Password = Password;
                    userRepository.Update(user);
                    TempData["PasswordEdited"] = "Password Changed.";
                }
                else
                {
                    TempData["CurrentPassword"] = "Current Password is incorrect.";
                }
            }
            else
            {
                TempData["ConfirmPassword"] = "New and Confirm does not match.";
            }
            return RedirectToAction("Account", new { id = Session["id"] });
        }
    }
}