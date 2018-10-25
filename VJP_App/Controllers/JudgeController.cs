using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJP_Entity;
using VJP_Interface;

namespace VJP_App.Controllers
{
    public class JudgeController : Controller
    {
        // GET: Judge


        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;

        public JudgeController
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



        public ActionResult Index()
        {
            if (Session["email"] != null && Session["userType"].ToString() == "3")
            {

                return View(eventRepository.GetRunningEvents());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult ViewProfile()
        {

            return View(judgeRepository.Get(Convert.ToInt32(Session["id"])));
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            Judge jd = judgeRepository.Get(Convert.ToInt32(Session["id"]));

            TempData["FName"] = jd.FirstName;
            TempData["LName"] = jd.LastName;
            TempData["Gen"] = jd.Gender;
            TempData["Abt"] = jd.About;

            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(Judge jd, string OldPassword, string NewPassword, string CNewPassword)
        {
            TempData["FName"] = jd.FirstName;
            TempData["LName"] = jd.LastName;
            TempData["Gen"] = jd.Gender;
            TempData["Abt"] = jd.About;

            jd.JudgeId = Convert.ToInt32(Session["id"]);
            User j = userRepository.Get(jd.JudgeId);
            if (NewPassword == CNewPassword)
            {
                if (j.Password == OldPassword)
                {
                    judgeRepository.Update(jd);
                    if (NewPassword != "")
                        j.Password = NewPassword;
                    userRepository.Update(j);
                    return RedirectToAction("ViewProfile", "Judge");
                }
                else
                {
                    TempData["Error"] = "Incorrect Password!";
                    return RedirectToAction("EditProfile", "Judge");
                }
            }
            else
            {
                TempData["Error"] = "Passwords don't match";
                return RedirectToAction("EditProfile", "Judge");
            }
        }
    }
}