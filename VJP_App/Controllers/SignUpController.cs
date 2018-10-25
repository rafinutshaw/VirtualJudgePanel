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
    public class SignUpController : Controller
    {
        private IAccountTypeRepository accountTypeRepository;
        private IUserRepository userRepository;
        public SignUpController(IAccountTypeRepository accountTypeRepository, IUserRepository userRepository)
        {
            this.accountTypeRepository = accountTypeRepository;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.AccountyType_Id = new SelectList(accountTypeRepository.GetAll(), "Id", "Type");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var check = userRepository.DuplicateEmail(user.Email);
                if (check)
                {
                    ViewBag.Avalilabe = "Email is already registerd!";
                    return View();
                }
                else
                {
                    user.AccountType_Id = 2;
                    user.CreateDate = DateTime.Now;

                    userRepository.Insert(user);
                    TempData["Create"] = "User created!";

                    return RedirectToAction("Index", "Users");
                }
            }
            else
            {
                TempData["CreateFailed"] = "User creation failed";

                return View();
            }
        }
    }
}