using AlgoOpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlgoOpp.Controllers
{
    public class CollegeRegisterController : Controller
    {
        // GET: CollegeRegister
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var data = new TechathonDB_user11Entities())
            {
                bool isValid = data.COLLEGE_DETAILS.Any(x => x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email_id, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid username or password");
                return View();

                //var UserDetail = data.COLLEGE_DETAILS.Where(x => x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password).FirstOrDefault();
                //if (UserDetail == null)
                //{
                //    ModelState.AddModelError("", "Invalid username or password");
                //    return View("Login", model);
                //}
                //else
                //{
                //    Session["EMAIL_ID"] = model.Email_id;
                //    //var UserName = from r in data.COMPANY_DETAILS where 


                //    return RedirectToAction("DashBoard", "CollegeRegister");
                //}
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(COLLEGE_DETAILS model)
        {
            using (var data = new TechathonDB_user11Entities())
            {
                data.COLLEGE_DETAILS.Add(model);
                data.SaveChanges();
            }
            return RedirectToAction("Login");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult Recrutiment()
        {
            return View();
        }
        public ActionResult StudentDetails()
        {
            return View();
        }
        public ActionResult StudentStatus()
        {
            return View();
        }
    }
}