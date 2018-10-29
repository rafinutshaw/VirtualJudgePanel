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
    public class LoginController : Controller
    {
        private IUserRepository userRepository;

        public LoginController(IUserRepository user)
        {
            this.userRepository = user;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["email"] != null && (int)Session["userType"] == 1)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (Session["email"] != null && (int)Session["userType"] == 2)
            {
                return RedirectToAction("Index", "Student");
            }
            else if (Session["email"] != null && (int)Session["userType"] == 3)
            {
                return RedirectToAction("Index", "Judge");
            }
            else if (Session["email"] != null && (int)Session["userType"] == 4)
            {
                return RedirectToAction("Index", "Organization");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid)
            {
                var valid = userRepository.GetByEmailAndPass(u);

                if (valid != null)
                {
                    Session["email"] = valid.Email;
                    Session["userType"] = valid.AccountType_Id;
                    Session["userTypeName"] = valid.AccountType.Type;
                    Session["id"] = valid.Id;

                    if (valid.AccountType_Id == 1)
                    {
                        ViewBag.Email = valid.Email;
                        ViewBag.Type = valid.AccountType_Id;
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (valid.AccountType_Id == 2)
                    {
                        ViewBag.Email = valid.Email;
                        ViewBag.Type = valid.AccountType_Id;
                        return RedirectToAction("Index", "Student");
                    }
                    else if (valid.AccountType_Id == 3)
                    {
                        ViewBag.Email = valid.Email;
                        ViewBag.Type = valid.AccountType_Id;
                        return RedirectToAction("Index", "Judge");
                    }
                    else if (valid.AccountType_Id == 4)
                    {
                        ViewBag.Email = valid.Email;
                        ViewBag.Type = valid.AccountType_Id;
                        return RedirectToAction("Index", "Organization");
                    }
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Notfound = "Email id or password is incorrect!";
                    return View(u);
                }
            }
            else
            {
                ModelState.Values.SelectMany(v => v.Errors).ElementAt(0);
                @TempData["msg"] = "Login Invalid";
                return View();
            }
        }
    }
}