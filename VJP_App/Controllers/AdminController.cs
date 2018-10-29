using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJP_Interface;
using VJP_Entity;

namespace VJP_App.Controllers
{
    public class AdminController : BaseController
    {
        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;
        private IProjectCategoryRepository projectCategoryRepository;
        private IProjectCategoryEventRepository projectCategoryEventRepository;

        public AdminController(IAccountTypeRepository accountTypeRepository,
            IUserRepository userRepository, IEventRepository eventRepository,
            IEventCategoryRepository eventCategoryRepository, IStudentRepository studentRepository,
            IJudgeRepository judgeRepository, IOrganizationRepository organizationRepository,
            IProjectCategoryRepository projectCategoryRepository,
            IProjectCategoryEventRepository projectCategoryEventRepository)
        {
            this.accountTypeRepository = accountTypeRepository;
            this.userRepository = userRepository;
            this.eventRepository = eventRepository;
            this.eventCategoryRepository = eventCategoryRepository;
            this.studentRepository = studentRepository;
            this.judgeRepository = judgeRepository;
            this.organizationRepository = organizationRepository;
            this.projectCategoryRepository = projectCategoryRepository;
            this.projectCategoryEventRepository = projectCategoryEventRepository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.TotalUsers = userRepository.GetAll().Count();
            ViewBag.TotalEvents = eventRepository.GetAll().Count();

            if (Session["email"] != null && Session["userType"].ToString() == "1")
            {
                return View();
            }
            return RedirectToAction("Index", "Login");

        }


        //  User

        [HttpGet]
        public ActionResult UserList()
        {

            return View(userRepository.GetAll());
        }

        [HttpGet]
        public ActionResult UserProfile(int Id)
        {

            return View(userRepository.Get(Id));
        }

        [HttpPost]
        public ActionResult EditUser(User us)
        {
            userRepository.Update(us);

            return RedirectToAction("UserList", "Admin");
        }
        [HttpPost]
        public ActionResult DeleteUser(User us)
        {
            userRepository.Delete(us.Id);

            return RedirectToAction("UserList", "Admin");
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.AccountyType_Id = new SelectList(accountTypeRepository.GetAll(), "Id", "Type");

            //ViewBag.cataType = userRepository.GetType();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            userRepository.Insert(user);

            if (user.AccountType_Id == 2)
            {
                Student student = new Student();
                student.StudentId = user.Id;
                studentRepository.Insert(student);
            }
            else if (user.AccountType_Id == 3)
            {
                Judge judge = new Judge();
                judge.JudgeId = user.Id;
                judgeRepository.Insert(judge);
            }
            else if (user.AccountType_Id == 4)
            {
                Organization organization = new Organization();
                organization.OrganizationId = user.Id;
                organizationRepository.Insert(organization);
            }

            return RedirectToAction("UserList", "Admin");
        }

        public ActionResult Details(int id)
        {
            return View(userRepository.Get(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(userRepository.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {

            if (id == 2)
            {
                studentRepository.Delete(id);
                userRepository.Delete(id);
                TempData["Deleted"] = "User deleted";
            }
            if (id == 3)
            {
                judgeRepository.Delete(id);
                userRepository.Delete(id);
                TempData["Deleted"] = "User deleted";
            }
            if (id == 4)
            {
                organizationRepository.Delete(id);
                userRepository.Delete(id);
                TempData["Deleted"] = "User deleted";
            }
            return RedirectToAction("Index");
        }


        //  Event


        [HttpGet]
        public ActionResult EventList()
        {
            return View(eventRepository.GetAll());
        }
        [HttpGet]
        public ActionResult CreateEvent()
        {
            ViewBag.Categories = projectCategoryRepository.GetAll().ToList();

            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event evnt, int[] categories)
        {

            eventRepository.Insert(evnt);

            ProjectCategoryEvent pce = new ProjectCategoryEvent();
            foreach (int cat in categories)
            {
                pce.EventId = evnt.Id;
                pce.ProjectCategoryId = cat;
                projectCategoryEventRepository.Insert(pce);
                pce = new ProjectCategoryEvent();
            }
            return RedirectToAction("EventList", "Admin");
        }
        public ActionResult EventDetails(int id)
        {
            //ViewBag.EventCategory = projectCategoryEventRepository.GetAll().FindAll(pc => pc.EventId == id).ToList();
            var item = projectCategoryEventRepository.GetAll().FindAll(pc => pc.EventId == id).ToList();
            ViewBag.EventCategory = item;

            return View(eventRepository.Get(id));
        }


        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            ViewBag.Categories = projectCategoryRepository.GetAll().ToList();
            ViewBag.ExCategories = projectCategoryEventRepository.GetAll().ToList().FindAll(cat => cat.EventId == id).ToList();
            return View(eventRepository.Get(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditEvent(Event Event, int[] categories)
        {
            if (ModelState.IsValid)
            {
                eventRepository.Update(Event);

                List<ProjectCategoryEvent> pce = projectCategoryEventRepository.GetAll().FindAll(pc => pc.EventId == Event.Id).ToList();
                

                TempData["Edited"] = "Event Edited.";

                var get_event = eventRepository.Get(Event.Id);

                return RedirectToAction("EventDetails", new { id = get_event.Id });
            }
            else
            {
                TempData["EditFailed"] = "Error occurs.";

                return View(Event);
            }
        }


        //  Categories


        [HttpGet]
        public ActionResult CategoryList()
        {
            return View(projectCategoryRepository.GetAll());
        }
        [HttpGet]
        public ActionResult CreateProjectCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProjectCategory(ProjectCategory projectCategory)
        {
            projectCategoryRepository.Insert(projectCategory);

            return RedirectToAction("CategoryList", "Admin");
        }
        public ActionResult ProjectCategoryDetails(int id)
        {
            return View(projectCategoryRepository.Get(id));
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            return View(projectCategoryRepository.Get(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditCategory(ProjectCategory projectCategory)
        {
            if (ModelState.IsValid)
            {
                projectCategoryRepository.Update(projectCategory);

                TempData["Edited"] = "Cateogory Edited.";

                var get_cateogry = eventRepository.Get(projectCategory.Id);

                return RedirectToAction("ProjectCategoryDetails", new { id = get_cateogry.Id });
            }
            else
            {
                TempData["EditFailed"] = "Error occurs.";

                return View(projectCategory);
            }
        }
    }
}