using AlgoOpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Membership = AlgoOpp.Models.Membership;

namespace AlgoOpp.Controllers
{
    public class CompanyRegisterController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var data = new TechathonDB_user11Model2())
            {
                //bool isValid = data.COMPANY_DETAILS.Any(x => x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password);
                //if (isValid)
                //{
                //    FormsAuthentication.SetAuthCookie(model.Email_id, false);
                //    return RedirectToAction("DashBoard", "CompanyRegister");
                //}
                //ModelState.AddModelError("", "Invalid username or password");
                //return View();
                var UserDetail = data.COMPANY_DETAILS.Where(x => x.EST_TYPE == model.Est_Type && x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password ).FirstOrDefault();
                if (UserDetail == null)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View("Login", model);
                }
                else
                {
                    Session["model"] = model;
                    //Session["EST_TYPE"] = model.Est_Type;
                    //Session["EMAIL_ID"] = model.Email_id;

                    return RedirectToAction("DashBoard"/*, "CompanyRegister"*/);
                }
                
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
            using (var data = new TechathonDB_user11Model2())
            {
                data.COMPANY_DETAILS.Add(model);
                data.SaveChanges();
            }
            return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "CompanyRegister");
        }
        public ActionResult DashBoard()
        {
            
            return View();
        }
        public ActionResult Recruitment()
        {

            return View();
        }
        public ActionResult Notification()
        {

            return View();
        }
        public ActionResult CheckStatus()
        {

            return View();
        }

    }
}