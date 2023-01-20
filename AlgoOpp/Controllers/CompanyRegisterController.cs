using AlgoOpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AlgoOpp.Models;

namespace AlgoOpp.Controllers
{
    public class CompanyRegisterController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var data = new TechathonDB_user11Entities2())
            {
                bool isValid = data.COMPANY_DETAILS.Any(x => x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email_id, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(COMPANY_DETAILS model)
        {
            ViewBag.Message = "Company";
            using (var data = new TechathonDB_user11Entities2())
            {
                data.COMPANY_DETAILS.Add(model);
                data.SaveChanges();
            }
            return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}