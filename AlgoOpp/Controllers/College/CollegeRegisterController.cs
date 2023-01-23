using AlgoOpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlgoOpp.Controllers
{
    public class CollegeRegisterController : Controller
    {
        TechathonDB_user11Entities3 db3 = new TechathonDB_user11Entities3();
        // GET: CollegeRegister
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var data = new TechathonDB_user11Entities())
            {

                var UserDetail = data.COLLEGE_DETAILS.Where(x => x.EST_TYPE == model.Est_Type && x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password ).FirstOrDefault();
                if (UserDetail == null)
                {
                    //ModelState.AddModelError("", "Invalid username or password");
                    return View("Login", model);
                }
                else
                {
                    
                    Session["model"] = model;
                    

                   
                    return RedirectToAction("DashBoard", "CollegeRegister");
                }
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
            
            Session.Abandon();
            return RedirectToAction("Login","CollegeRegister");
        }

        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult StudentDetails()
        {
            return View();
        }
        public ActionResult Companies()
        {
            return View(db3.RECRUIT_APP_STATUS_CL.ToList());
            
        }
        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult Apply(int id)
        {
            if (id <= 0 )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECRUIT_APP_STATUS_CL edit = db3.RECRUIT_APP_STATUS_CL.Find(id);
            if (edit == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }
        [Route("[action]/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(RECRUIT_APP_STATUS_CL recruit, int Id)
        {
            var data = db3.RECRUIT_APP_STATUS_CL.FirstOrDefault(x => x.NOTIFY_ID == Id);

            if (data != null)
            {
                
                data.APP_STATUS = "Applied";
                data.APPLIED_DATE = DateTime.Now;
               
                db3.SaveChanges();
            }
            return RedirectToAction("Companies");

        }
        public ActionResult Reject()
        {
            return View();
        }
        public ActionResult StudentStatus()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Notification()
        {
            return PartialView("_Notification");
        }
    }
}