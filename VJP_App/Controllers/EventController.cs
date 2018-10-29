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
    public class EventController : BaseController
    {
        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private IEventCategoryRepository eventCategoryRepository;
        private IStudentRepository studentRepository;
        private IJudgeRepository judgeRepository;
        private IOrganizationRepository organizationRepository;

        public EventController
            (
                IAccountTypeRepository accountTypeRepository,
                IUserRepository userRepository, IEventRepository eventRepository,
                IEventCategoryRepository eventCategoryRepository, IStudentRepository studentRepository,
                IJudgeRepository judgeRepository, IOrganizationRepository organizationRepository
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
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(eventRepository.Get(id));
        }
    }
}