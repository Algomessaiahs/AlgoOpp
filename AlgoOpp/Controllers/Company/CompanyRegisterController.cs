using AlgoOpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Membership = AlgoOpp.Models.Membership;

namespace AlgoOpp.Controllers
{
    public class CompanyRegisterController : Controller
    {
       RecruitmentAppStatusNotify_CY db = new RecruitmentAppStatusNotify_CY();
        // GET: Account
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var data = new TechathonDB_user11Entities2())
            {

                var UserDetail = data.COMPANY_DETAILS.Where(x => x.EST_TYPE == model.Est_Type && x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password).FirstOrDefault();
                if (UserDetail == null)
                {
                    //ModelState.AddModelError("", "Invalid username or password");
                    return View("Login", model);
                }
                else
                {
                    Session["model"] = model;


                    return RedirectToAction("DashBoard");
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
            using (var data = new TechathonDB_user11Entities2())
            {
                data.COMPANY_DETAILS.Add(model);
                data.SaveChanges();
            }
            return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {

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

        public ActionResult CheckStatus()
        {

            return View();
        }

        public ActionResult Notification()
        {

            return View(db.RECRUIT_APP_STATUS_CY.ToList());
        }
        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult Approve(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECRUIT_APP_STATUS_CY edit = db.RECRUIT_APP_STATUS_CY.Find(id);
            if (edit == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }
        [Route("[action]/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(RECRUIT_APP_STATUS_CY recruit, int Id)
        {
            var data = db.RECRUIT_APP_STATUS_CY.FirstOrDefault(x => x.NOTIFY_ID_CY == Id);

            if (data != null)
            {

                data.APPROVAL_STATUS = "Approved";


                db.SaveChanges();
            }
            return RedirectToAction("Notification");
        }
    }
}