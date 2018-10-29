using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJP_Interface;
using VJP_Entity;
using System.Threading.Tasks;
using System.Net.Http;

using System.Net;

using System.IO;
using System.Net.Mime;

namespace VJP_App.Controllers
{
    public class StudentController : BaseController
    {
        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventSubscribeRepository eventSubscribeRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;
        private IJobPostRepository jobPostRepository;
        private IJobCategoryRepository jobCategoryRepository;
        private IJobApplyActivityRepository jobApplyActivityRepository;
        private IProjectRepository projectRepository;
        private IProjectCategoryEventRepository projectCategoryEventRepository;

        public StudentController
            (
                IAccountTypeRepository accountTypeRepository,
                IUserRepository userRepository,
                IEventRepository eventRepository,
                IEventCategoryRepository eventCategoryRepository,
                IStudentRepository studentRepository,
                IJudgeRepository judgeRepository,
                IOrganizationRepository organizationRepository,
                IJobPostRepository jobPostRepository,
                IJobCategoryRepository jobCategoryRepository,
                IJobApplyActivityRepository jobApplyActivityRepository,
                IEventSubscribeRepository eventSubscribeRepository,
                IProjectRepository projectRepository,
                IProjectCategoryEventRepository projectCategoryEventRepository

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
            this.jobCategoryRepository = jobCategoryRepository;
            this.jobApplyActivityRepository = jobApplyActivityRepository;
            this.eventSubscribeRepository = eventSubscribeRepository;
            this.projectRepository = projectRepository;
            this.projectCategoryEventRepository = projectCategoryEventRepository;
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

                TempData["Edited"] = "Profile Edited.";

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

        //alucard
        [HttpGet]
        public ActionResult Jobs()
        {

            return View(jobPostRepository.GetAll());
        }
        [HttpGet]
        public ActionResult ViewJob(int id)
        {
            TempData["Applied"] = false;
            if (jobApplyActivityRepository.GetAll().FindAll(ac => ac.StudentId == (int)Session["id"] && ac.Id == id).ToList().Count != 0)
                TempData["Applied"] = true;
            return View(jobPostRepository.Get(id));
        }
        [HttpPost]
        public ActionResult ViewJob(JobPost jp)
        {
            jp = jobPostRepository.Get(jp.Id);
            if (!(jp.LastDate >= DateTime.Now))
            {
                TempData["Error"] = "Not Allowed";
                return RedirectToAction("ViewJob", "Student", new { id = jp.Id });
            }
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/CVUploads"), fileName);

                JobApplyActivity ac = new JobApplyActivity();
                ac.StudentId = (int)Session["id"];
                ac.JobPostId = jp.Id;
                ac.ApplyDate = DateTime.Now;
                ac.path = fileName;
                jobApplyActivityRepository.Insert(ac);

                file.SaveAs(path);
            }

            return RedirectToAction("ViewJob", "Student", new { id = jp.Id });
        }
        [HttpGet]
        public ActionResult AppliedJobs()
        {

            return View(jobApplyActivityRepository.GetAll().FindAll(ac => ac.StudentId == (int)Session["id"]));
        }
        [HttpGet]
        public ActionResult Event(int id)
        {
            List<ProjectCategoryEvent> pvc = projectCategoryEventRepository.GetAll().FindAll(pc => pc.EventId == id).ToList();
            ViewBag.Categories = projectCategoryEventRepository.GetAll().FindAll(pc => pc.EventId == id).ToList();
            ViewBag.Subs = false;
            ViewBag.Pro = projectRepository.GetAll().FindAll(pr => pr.EventId == id && pr.PostedBy == (int)Session["id"]).ToList();
            if (eventSubscribeRepository.GetAll().FindAll(e => e.StudentId == (int)Session["id"] && e.EventId == id).ToList().Count != 0)
                ViewBag.Subs = true;
            return View(eventRepository.Get(id));
        }
        [HttpPost]

        public ActionResult Event(Project pr)
        {
            Event ev = eventRepository.Get(pr.Id);
            if (!(ev.ClosingDate >= DateTime.Now && ev.StartingDate <= DateTime.Now))
            {
                TempData["Error"] = "Not Allowed";
                return RedirectToAction("Event", "Student", new { id = pr.Id });
            }
            else if (projectRepository.GetAll().FindAll(p => p.EventId == pr.Id && p.ProjectCategoryId == pr.ProjectCategoryId && p.PostedBy == (int)Session["id"]).ToList().Count != 0)
            {
                TempData["Error"] = "Not Allowed";
                return RedirectToAction("Event", "Student", new { id = pr.Id });
            }
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/ProjectUploads"), fileName);

                pr.EventId = pr.Id;
                pr.PostedBy = (int)Session["id"];
                pr.PostingDate = DateTime.Now;
                pr.Path = fileName;
                projectRepository.Insert(pr);
                file.SaveAs(path);
            }
            return RedirectToAction("Event", new { pr.EventId });
        }
        [HttpGet]
        public void EventSub(int id)
        {

            EventSubscribe es = new EventSubscribe { StudentId = (int)Session["id"], EventId = id };
            eventSubscribeRepository.Insert(es);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        [HttpGet]
        public ActionResult SubscribedEvents()
        {
            return View(eventSubscribeRepository.GetAll().FindAll(e => e.StudentId == (int)Session["id"]).ToList());
        }
        [HttpPost]
        public ActionResult FileUpload(int id)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
        public ActionResult UploadEventProject(int id)
        {
            return View();
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