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
                //bool isValid = data.COLLEGE_DETAILS.Any(x => x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password);
                //if (isValid)
                //{
                //    FormsAuthentication.SetAuthCookie(model.Email_id, false);
                //    return RedirectToAction("Index", "Home");
                //}
                //ModelState.AddModelError("", "Invalid username or password");
                //return View();

                var UserDetail = data.COLLEGE_DETAILS.Where(x => x.EST_TYPE == model.Est_Type && x.EMAIL_ID == model.Email_id && x.PASSWORD == model.Password ).FirstOrDefault();
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
                    //var UserName = from r in data.COMPANY_DETAILS where 

                   
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
            //FormsAuthentication.SignOut();
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

        public ActionResult Apply(int? id)
        {
            if (id == null)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(RECRUIT_APP_STATUS_CL recruit, int Id)
        {
            var data = db3.RECRUIT_APP_STATUS_CL.FirstOrDefault(x => x.NOTIFY_ID == Id);

            if (data != null)
            {
                //recruit.EST_ID = data.EST_ID;
                //recruit.EST_NAME = data.EST_NAME;
                //recruit.POSITION = data.POSITION;
                //recruit.JOB_LOCATION = data.JOB_LOCATION;
                //recruit.JOB_DESC = data.JOB_DESC;
                //recruit.SKILLS_REQ = data.SKILLS_REQ;
                //recruit.REQ_CGPA = data.REQ_CGPA;
                //recruit.CREATED_DATE = data.CREATED_DATE;
                //recruit.RECRUIT_ID = data.RECRUIT_ID;
                recruit.APP_STATUS = "Apply";
                recruit.APPLIED_DATE = DateTime.Now;
                //db3.RECRUIT_APP_STATUS_CL.Add(recruit);
                db3.SaveChanges();
            }
            return View(db3.RECRUIT_APP_STATUS_CL.ToList());

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