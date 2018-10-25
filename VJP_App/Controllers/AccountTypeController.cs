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
    public class AccountTypeController : Controller
    {
        private IAccountTypeRepository accountTypeRepository;

        public AccountTypeController(IAccountTypeRepository accountTypeRepository)
        {
            this.accountTypeRepository = accountTypeRepository;
        }

        // GET: AccountType
        public ActionResult Index()
        {
            return View(accountTypeRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountType accountType)
        {
            if (ModelState.IsValid)
            {
                accountTypeRepository.Insert(accountType);
                TempData["Create"] = "Account type created!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["CreateFailed"] = "Creation failed";

                return RedirectToAction("Create");
            }
        }

        public ActionResult Details(int id)
        {
            return View(accountTypeRepository.Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(accountTypeRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(AccountType accountType)
        {
            if (ModelState.IsValid)
            {
                accountTypeRepository.Update(accountType);

                TempData["Edited"] = "Account Type Edited.";

                return RedirectToAction("Details", new { id = accountType.Id });
            }
            else
            {
                TempData["EditFailed"] = "Error occurs.";

                return View(accountType);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(accountTypeRepository.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            accountTypeRepository.Delete(id);
            TempData["Deleted"] = "Account Type Deleted";

            return RedirectToAction("Index");
        }
    }
}
