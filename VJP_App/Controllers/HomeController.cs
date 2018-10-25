using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VJP_Repository;
using VJP_Interface;

namespace VJP_App.Controllers
{
    public class HomeController : Controller
    {

        private IEventRepository eventRepository;

        public HomeController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public ActionResult Index()
        {
            return View();

            //return View(eventRepository.GetAll());
        }
        public ActionResult Angular()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}