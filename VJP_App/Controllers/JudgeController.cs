using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using VJP_Entity;
using VJP_Interface;

namespace VJP_App.Controllers
{
    public class JudgeController : BaseController
    {
        // GET: Judge


        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;
        private IProjectRepository projectRepository;
        private IRatingRepository ratingRepository;

        public JudgeController
            (
            IAccountTypeRepository accountTypeRepository,
            IUserRepository userRepository,
            IEventRepository eventRepository,
            IEventCategoryRepository eventCategoryRepository,
            IStudentRepository studentRepository,
            IJudgeRepository judgeRepository,
            IOrganizationRepository organizationRepository,
             IProjectRepository projectRepository,
            IRatingRepository ratingRepository
            )
        {
            this.projectRepository = projectRepository;
            this.accountTypeRepository = accountTypeRepository;
            this.userRepository = userRepository;
            this.eventRepository = eventRepository;
            this.eventCategoryRepository = eventCategoryRepository;
            this.studentRepository = studentRepository;
            this.judgeRepository = judgeRepository;
            this.organizationRepository = organizationRepository;
            this.ratingRepository = ratingRepository;
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

        //[HttpGet]
        //public ActionResult EditProfile()
        //{
        //    Judge jd = judgeRepository.Get(Convert.ToInt32(Session["id"]));

        //    TempData["FName"] = jd.FirstName;
        //    TempData["LName"] = jd.LastName;
        //    TempData["Gen"] = jd.Gender;
        //    TempData["Abt"] = jd.About;

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult EditProfile(Judge jd, string OldPassword, string NewPassword, string CNewPassword)
        //{
        //    TempData["FName"] = jd.FirstName;
        //    TempData["LName"] = jd.LastName;
        //    TempData["Gen"] = jd.Gender;
        //    TempData["Abt"] = jd.About;

        //    jd.JudgeId = Convert.ToInt32(Session["id"]);
        //    User j = userRepository.Get(jd.JudgeId);
        //    if (NewPassword == CNewPassword)
        //    {
        //        if (j.Password == OldPassword)
        //        {
        //            judgeRepository.Update(jd);
        //            if (NewPassword != "")
        //                j.Password = NewPassword;
        //            userRepository.Update(j);
        //            return RedirectToAction("ViewProfile", "Judge");
        //        }
        //        else
        //        {
        //            TempData["Error"] = "Incorrect Password!";
        //            return RedirectToAction("EditProfile", "Judge");
        //        }
        //    }
        //    else
        //    {
        //        TempData["Error"] = "Passwords don't match";
        //        return RedirectToAction("EditProfile", "Judge");
        //    }
        //}


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(judgeRepository.Get(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Judge judge)
        {
            if (ModelState.IsValid)
            {
                judgeRepository.Update(judge);

                TempData["Edited"] = "Profile Edited.";

                return RedirectToAction("Edit", new { id = Session["id"] });
            }
            else
            {
                TempData["EditFailed"] = "Error occurs.";

                return View(judge);
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


        [HttpGet]
        public ActionResult EventProjects(int id)
        {
            ViewBag.Ratings = ratingRepository.GetAll().FindAll(rt => rt.JudgeId == (int)Session["id"] && rt.Project.EventId == id).ToList();
            return View(projectRepository.GetAll().FindAll(ev => ev.EventId == id).ToList());
        }
        [HttpGet]
        public void RateProject(Rating rt)
        {
            rt.JudgeId = (int)Session["id"];
            Rating rating = ratingRepository.GetAll().Find(r => r.JudgeId == (int)Session["id"] && r.ProjectId == rt.ProjectId);
            if (rating == null)
                ratingRepository.Insert(rt);
            else
            {
                rating.Ratings = rt.Ratings;

                ratingRepository.Update(rating);
            }
            CalcTotalRating(rt.ProjectId);


        }
        public void CalcTotalRating(int project_id)
        {
            List<Rating> rates = ratingRepository.GetAll().FindAll(rt => rt.ProjectId == project_id).ToList();
            Double rating = 0;
            foreach (Rating rt in rates)
            {
                rating += rt.Ratings;
            }
            Project pro = projectRepository.GetAll().Find(pr => pr.Id == project_id);

            pro.TotalRatings = rating / rates.Count;
            projectRepository.Update(pro);
        }
        public ActionResult ViewEventResult(int eventId)
        {
            return View(projectRepository.GetAll().FindAll(pro => pro.EventId == eventId).ToList());
        }
        public ActionResult AllEvents()
        {
            return View(eventRepository.GetAll().ToList());
        }
        public FileResult DownloadProject(string name, string path)
        {
            return File(@"" + Server.MapPath("~/App_Data/ProjectUploads") + "/" + path, MediaTypeNames.Application.Octet, name + Path.GetExtension(path));
        }
        public FileResult DownloadCV(string name, string path)
        {
            return File(@"" + Server.MapPath("~/App_Data/CVUploads") + "/" + path, MediaTypeNames.Application.Octet, name + Path.GetExtension(path));
        }
    }
}