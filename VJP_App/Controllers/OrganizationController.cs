using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJP_Entity;
using VJP_Interface;

namespace VJP_App.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Judge


        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;

        public OrganizationController
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
            if (Session["email"] != null && Session["userType"].ToString() == "4")
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

            return View(organizationRepository.Get(Convert.ToInt32(Session["id"])));
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            Organization jd = organizationRepository.Get(Convert.ToInt32(Session["id"]));

            TempData["Na"] = jd.Name;
            TempData["Add"] = jd.Address;
            TempData["Web"] = jd.WebUrl;
            TempData["Des"] = jd.Description;

            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(Organization jd, string OldPassword, string NewPassword, string CNewPassword)
        {
            TempData["Na"] = jd.Name;
            TempData["Add"] = jd.Address;
            TempData["Web"] = jd.WebUrl;
            TempData["Des"] = jd.Description;

            jd.OrganizationId = Convert.ToInt32(Session["id"]);
            User j = userRepository.Get(jd.OrganizationId);
            if (NewPassword == CNewPassword)
            {
                if (j.Password == OldPassword)
                {
                    organizationRepository.Update(jd);
                    if (NewPassword != "")
                        j.Password = NewPassword;
                    userRepository.Update(j);
                    return RedirectToAction("ViewProfile", "Organization");
                }
                else
                {
                    TempData["Error"] = "Incorrect Password!";
                    return RedirectToAction("EditProfile", "Organization");
                }
            }
            else
            {
                TempData["Error"] = "Passwords don't match";
                return RedirectToAction("EditProfile", "Organization");
            }
        }
    }
}