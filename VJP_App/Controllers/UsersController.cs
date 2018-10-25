using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VJP_Entity;
using VJP_Interface;
using VJP_Repository;

namespace VJP_App.Controllers
{
    public class UsersController : Controller
    {
        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;

        public UsersController(IAccountTypeRepository accountTypeRepository, IUserRepository userRepository)
        {
            this.accountTypeRepository = accountTypeRepository;
            this.userRepository = userRepository;
        }
        
        public ActionResult Index()
        {
            return View(userRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AccountyType_Id = new SelectList(accountTypeRepository.GetAll(), "Id", "Type");

            return View();
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.CreateDate = DateTime.Now;

                userRepository.Insert(user);
                TempData["Create"] = "User created!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["CreateFailed"] = "User creation failed";

                return RedirectToAction("Create");
            }
        }
        
        public ActionResult Details(int id)
        {
            return View(userRepository.Get(id));
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Demo = "Demo";
            ViewBag.AccountyType_Id = new SelectList(accountTypeRepository.GetAll(), "Id", "Type");

            return View(userRepository.Get(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Update(user);
                
                TempData["Edited"] = "Account Type Edited.";

                return RedirectToAction("Details", new { id = user.Id });
            }
            else
            {
                TempData["EditFailed"] = "Error occurs.";

                return View(user);
            }
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
            userRepository.Delete(id);
            TempData["Deleted"] = "User deleted";

            return RedirectToAction("Index");
        }
    }
}
