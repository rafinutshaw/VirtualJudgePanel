using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJP_Interface;
using VJP_Entity;

namespace VJP_App.Controllers
{
    public class AdminController : Controller
    {

        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;

        public AdminController(IAccountTypeRepository accountTypeRepository, 
            IUserRepository userRepository, IEventRepository eventRepository, 
            IEventCategoryRepository eventCategoryRepository, IStudentRepository studentRepository, 
            IJudgeRepository judgeRepository, IOrganizationRepository organizationRepository)
        {
            this.accountTypeRepository = accountTypeRepository;
            this.userRepository = userRepository;
            this.eventRepository = eventRepository;
            this.eventCategoryRepository= eventCategoryRepository;
            this.studentRepository = studentRepository;
            this.judgeRepository = judgeRepository;
            this.organizationRepository = organizationRepository;
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


        [HttpGet]
        public ActionResult EventList()
        {

            return View(eventRepository.GetAll());
        }
        [HttpGet]
        public ActionResult CreateEvent()
        {
            ViewBag.cataType = eventCategoryRepository.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event evnt)
        {
            eventRepository.Insert(evnt);

            return RedirectToAction("EventList", "Admin");
        }


        public ActionResult EventCategory()
        {
            return View(eventCategoryRepository.GetAll());
        }

        [ActionName("AddCategory")]
        public ActionResult AddEventCategory()
        {
            return View();
        }

        [HttpPost, ActionName("AddCategory")]
        public ActionResult AddEventCategory(EventCategory eventCategory)
        {
            eventCategoryRepository.Insert(eventCategory);
            return RedirectToAction("EventCategory", "Admin");
        }

        [HttpPost]
        public ActionResult EditCategory(EventCategory eventCategory)
        {
            eventCategoryRepository.Update(eventCategory);

            return RedirectToAction("EventCategory", "Admin");
        }


        [HttpGet]
        public  ActionResult DeleteCategory(int id)
        {
            return View(eventCategoryRepository.Get(id));
        }


        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirm(int id)
        {
            try
            {
                eventCategoryRepository.Delete(id);
                TempData["DoneM"] = "Category deleted.";
            }
            catch (Exception e)
            {
                TempData["ErrorM"] = "This category already assoniated with event(s).";
                return RedirectToAction("DeleteCategory","Admin");
            }
            return RedirectToAction("EventCategory", "Admin");
        }
    }
}