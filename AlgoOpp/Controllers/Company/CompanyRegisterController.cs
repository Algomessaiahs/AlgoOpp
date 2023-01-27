using AlgoOpp.Models;
using Microsoft.Ajax.Utilities;
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
        TechathonDB_user11Entities5 db2 = new TechathonDB_user11Entities5();
        TechathonDB_user11Entities6 db4 = new TechathonDB_user11Entities6();
        TechathonDB_user11Entities2 db1 = new TechathonDB_user11Entities2();
        
        StudentDetails db3 = new StudentDetails();
        
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
            var session = (AlgoOpp.Models.Membership)Session["model"];
            var data = session.Email_id;
            var data2 = db1.COMPANY_DETAILS.FirstOrDefault(x => x.EMAIL_ID == data.ToString());
            var data3 = data2.EST_ID;
            return View(db.RECRUIT_APP_STATUS_CY.Where(x => x.EST_ID_CY == data3).ToList());
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
        public ActionResult Approve(RECRUIT_APP_STATUS_CY recruit, int Id, INTERVIEW_STATUS_CY interview, INTERVIEW_STATUS_CL interview2)
        {
            var data = db.RECRUIT_APP_STATUS_CY.FirstOrDefault(x => x.NOTIFY_ID_CY == Id);
            var data2 = db3.STUDENT_DETAILS.FirstOrDefault(x => x.EST_ID == data.EST_ID_CL);


            
            if (data != null && data.APP_STATUS == "Applied")
            {

                data.APPROVAL_STATUS = "Approved";
                db.SaveChanges();

                if(data.APPROVAL_STATUS == "Approved" && data.APP_STATUS == "Applied")
                {
                    interview.STUD_NAME = data2.NAME;
                    interview.STUD_ID = data2.STUD_ID;
                    interview.EMAIL_ID = data2.EMAIL_ID;
                    interview.MOBILE = data2.MOBILE;
                    interview.DEPARTMENT = data2.DEPARTMENT; 
                    interview.YEAR = data2.YEAR;
                    interview.CGPA= data2.CGPA;
                    interview.EST_ID_CL = data2.EST_ID;
                    interview.EST_ID_CY = data.EST_ID_CY;
                    interview.NOTIFY_ID_CL = data.NOTIFY_ID_CL;
                    interview.NOTIFY_ID_CY = data.NOTIFY_ID_CY;
                    interview.RECRUIT_ID_CY = data.RECRUIT_ID;

                    db2.INTERVIEW_STATUS_CY.Add(interview);
                    db2.SaveChanges();

                    interview2.STUD_NAME = interview.STUD_NAME;
                    interview2.STUD_ID = interview.STUD_ID;
                    interview2.EMAIL_ID = interview.EMAIL_ID;
                    interview2.MOBILE = interview.MOBILE;
                    interview2.DEPARTMENT = interview.DEPARTMENT;
                    interview2.YEAR = interview.YEAR;
                    interview2.CGPA = interview.CGPA;
                    interview2.EST_ID_CL = interview.EST_ID_CL;
                    interview2.EST_ID_CY = interview.EST_ID_CY;
                    interview2.NOTIFY_ID_CL = interview.NOTIFY_ID_CL;
                    interview2.NOTIFY_ID_CY = interview.NOTIFY_ID_CY;
                    interview2.RECRUIT_ID_CY = interview.RECRUIT_ID_CY;
                    interview2.INTERVIEW_ID_CY = interview.INTERVIEW_ID;

                    db4.INTERVIEW_STATUS_CL.Add(interview2);
                    db4.SaveChanges();
                }                

            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>confirm('No Colleges Have Applied Yet!');</script>");
            }

            return RedirectToAction("Notification");
        }
    }
}