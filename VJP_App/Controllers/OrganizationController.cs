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
    public class OrganizationController : BaseController
    {
        // GET: Judge


        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;
        private IJobPostRepository jobPostRepository;
        private IJobCategoryRepository JobCategoryRepository;
        private IJobApplyActivityRepository jobApplyActivityRepository;

        public OrganizationController
            (
            IAccountTypeRepository accountTypeRepository,
            IUserRepository userRepository,
            IEventRepository eventRepository,
            IEventCategoryRepository eventCategoryRepository,
            IStudentRepository studentRepository,
            IJudgeRepository judgeRepository,
            IOrganizationRepository organizationRepository,
            IJobPostRepository jobPostRepository,
            IJobCategoryRepository JobCategoryRepository,
            IJobApplyActivityRepository jobApplyActivityRepository
            )
        {
            this.accountTypeRepository = accountTypeRepository;
            this.userRepository = userRepository;
            this.eventRepository = eventRepository;
            this.eventCategoryRepository = eventCategoryRepository;
            this.studentRepository = studentRepository;
            this.judgeRepository = judgeRepository;
            this.organizationRepository = organizationRepository;
            this.jobPostRepository = jobPostRepository;
            this.JobCategoryRepository =JobCategoryRepository;
            this.jobApplyActivityRepository =jobApplyActivityRepository;
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
        [HttpGet]
        public ActionResult JobPostAndApplicants()
        {
            List<JobPost> jp = jobPostRepository.GetAll().ToList().FindAll(j => j.PostedBy == (Int32)Session["id"]);
            return View(jp);
        }
        [HttpGet]
        public ActionResult NewJobPost()
        {
            return View(JobCategoryRepository.GetAll());

        }
        [HttpPost]
        public ActionResult NewJobPost(JobPost jp)
        {

            jp.PostedBy = (int)Session["id"];
            jobPostRepository.Insert(jp);
            return RedirectToAction("JobPostAndApplicants");

        }



        [HttpGet]
        public ActionResult EditJobPost(int id)
        {
            ViewBag.Categories = JobCategoryRepository.GetAll();

            return View(jobPostRepository.Get(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditJobPost(JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                JobPost jp = jobPostRepository.Get(jobPost.Id);
                jp.Address = jobPost.Address;
                jp.Description = jobPost.Description;
                jp.FullTimeJob = jobPost.FullTimeJob;
                jp.JobCategoryId = jobPost.JobCategoryId;
                jp.JobTitle = jobPost.JobTitle;
                jp.LastDate = jobPost.LastDate;

                jp.PostedBy = (int)Session["id"];
                jp.PostingDate = jobPost.PostingDate;
                jobPostRepository.Update(jp);

                TempData["Edited"] = "Account Type Edited.";

                return RedirectToAction("JobPostAndApplicants", new { id = Session["id"] });
            }
            else
            {
                TempData["EditFailed"] = "Error occurs.";

                return View(jobPost);
            }
        }
        [HttpGet]
        public ActionResult ViewApplicants(int id)
        {
            return View(jobApplyActivityRepository.GetAll().FindAll(ar => ar.JobPostId == id));
        }
        [HttpGet]
        public ActionResult ViewStudentProfile(int id)
        {
            return View(studentRepository.Get(id));
        }
        public FileResult DownloadProject(string name, string path)
        {
            return File(@"" + Server.MapPath("~/App_Data/ProjectUploads/") + path, MediaTypeNames.Application.Octet, name + Path.GetExtension(path));
        }
        public FileResult DownloadCV(string name, string path)
        {
            return File(@"" + Server.MapPath("~/App_Data/CVUploads/") + path, MediaTypeNames.Application.Octet, name + Path.GetExtension(path));
        }
    }
}