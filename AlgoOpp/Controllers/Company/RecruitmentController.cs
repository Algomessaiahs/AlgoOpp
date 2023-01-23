using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlgoOpp.Models;
using Microsoft.Ajax.Utilities;

namespace AlgoOpp.Controllers.Company
{
    public class RecruitmentController : Controller
    {
        private TechathonDB_user11Entities1 db = new TechathonDB_user11Entities1();
        private TechathonDB_user11Model2 db2 = new TechathonDB_user11Model2();
        private TechathonDB_user11Entities3 db3 = new TechathonDB_user11Entities3();

        
        // GET: Recruitment
        public ActionResult Index()
        {//changed
            var session = (AlgoOpp.Models.Membership)Session["model"];
            var data = session.Email_id;
            var data2 = db2.COMPANY_DETAILS.FirstOrDefault(x => x.EMAIL_ID == data.ToString());
            var data3 = Convert.ToInt32(data2.EST_ID);
            return View(db.RECRUITMENTs.Where(x => x.EST_ID == data3).ToList());

            
        }

        // GET: Recruitment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECRUITMENT rECRUITMENT = db.RECRUITMENTs.Find(id);
            if (rECRUITMENT == null)
            {
                return HttpNotFound();
            }
            return View(rECRUITMENT);
        }

        // GET: Recruitment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recruitment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RECRUIT_ID,POSITION,JOB_LOCATION,SKILLS_REQ,JOB_DESC,REQ_CGPA")] RECRUITMENT rECRUITMENT)
        {
           

            if (ModelState.IsValid)
            {
                var session = (AlgoOpp.Models.Membership)Session["model"];
                var data = session.Email_id;
                var data2 = db2.COMPANY_DETAILS.FirstOrDefault(x => x.EMAIL_ID == data.ToString());

                rECRUITMENT.EST_ID = data2.EST_ID;
                rECRUITMENT.CREATED_BY = data2.EST_NAME;
                rECRUITMENT.CREATED_DATE = DateTime.Now;

                db.RECRUITMENTs.Add(rECRUITMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rECRUITMENT);
        }

        // GET: Recruitment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECRUITMENT rECRUITMENT = db.RECRUITMENTs.Find(id);
            if (rECRUITMENT == null)
            {
                return HttpNotFound();
            }
            return View(rECRUITMENT);
        }

        // POST: Recruitment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RECRUIT_ID,POSITION,JOB_LOCATION,SKILLS_REQ,JOB_DESC,REQ_CGPA,CREATED_DATE,CREATED_BY,MODIFIED_DATE,MODIFIED_BY,EST_ID")] RECRUITMENT rECRUITMENT,int recruit_id,COMPANY_DETAILS company)
        {
            //var est_id = from x in dbcompany.COMPANY_DETAILS where x.EMAIL_ID.Equals(Session["Email_id"]) select x.EST_ID;
            var session = (AlgoOpp.Models.Membership)Session["model"];
            var data3 = session.Email_id;
            var data2 = db2.COMPANY_DETAILS.FirstOrDefault(x => x.EMAIL_ID == data3.ToString());

            var data = db.RECRUITMENTs.FirstOrDefault(x => x.RECRUIT_ID == recruit_id);
            if (data != null)
            {
                data.POSITION = rECRUITMENT.POSITION;
                data.JOB_LOCATION = rECRUITMENT.JOB_LOCATION;
                data.SKILLS_REQ = rECRUITMENT.SKILLS_REQ;
                data.JOB_DESC = rECRUITMENT.JOB_DESC;
                data.REQ_CGPA = rECRUITMENT.REQ_CGPA;
                data.CREATED_DATE = rECRUITMENT.CREATED_DATE;
                rECRUITMENT.MODIFIED_DATE = DateTime.Now;
                data.MODIFIED_DATE = rECRUITMENT.MODIFIED_DATE;
                rECRUITMENT.CREATED_BY = data2.EST_NAME;
                data.MODIFIED_BY = rECRUITMENT.CREATED_BY;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(rECRUITMENT);
        }

        // GET: Recruitment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECRUITMENT rECRUITMENT = db.RECRUITMENTs.Find(id);
            if (rECRUITMENT == null)
            {
                return HttpNotFound();
            }
            return View(rECRUITMENT);
        }

        // POST: Recruitment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECRUITMENT rECRUITMENT = db.RECRUITMENTs.Find(id);
            db.RECRUITMENTs.Remove(rECRUITMENT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       //send the recruitment details to college Companies
        public ActionResult Send(RECRUIT_APP_STATUS_CL recruit,int id)
        {
            var data = db.RECRUITMENTs.FirstOrDefault(x => x.RECRUIT_ID == id);
            var session = (AlgoOpp.Models.Membership)Session["model"];
            var data3 = session.Email_id;
            var data2 = db2.COMPANY_DETAILS.FirstOrDefault(x => x.EMAIL_ID == data3.ToString());
            if (data!=null)
            {
                          
                 recruit.RECRUIT_ID = data.RECRUIT_ID;
                 recruit.EST_ID = data.EST_ID;
                 recruit.EST_NAME = data.CREATED_BY;
                 recruit.POSITION = data.POSITION;
                 recruit.JOB_LOCATION = data.JOB_LOCATION;
                 recruit.SKILLS_REQ = data.SKILLS_REQ;
                 recruit.CREATED_DATE = data.CREATED_DATE;
                 recruit.EST_NAME = data2.EST_NAME;
                 recruit.JOB_DESC = data.JOB_DESC;
                 recruit.REQ_CGPA = data.REQ_CGPA;

                db3.RECRUIT_APP_STATUS_CL.Add(recruit);
                db3.SaveChanges();
                

            }//changed
            return RedirectToAction("Index", new {msg="success"});
        }
    }
}
