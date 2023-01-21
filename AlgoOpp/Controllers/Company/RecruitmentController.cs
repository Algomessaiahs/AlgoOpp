//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.EnterpriseServices;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using AlgoOpp.Models;
//using Microsoft.Ajax.Utilities;

//namespace AlgoOpp.Controllers.Company
//{
//    public class RecruitmentController : Controller
//    {
//        private TechathonDB_user11Entities1 db = new TechathonDB_user11Entities1();

//        private Nullable<System.DateTime>  created_date;
//        // GET: Recruitment
//        public ActionResult Index()
//        {
//            return View(db.RECRUITMENTs.ToList());
//        }

//        // GET: Recruitment/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RECRUITMENT rECRUITMENT = db.RECRUITMENTs.Find(id);
//            if (rECRUITMENT == null)
//            {
//                return HttpNotFound();
//            }
//            return View(rECRUITMENT);
//        }

//        // GET: Recruitment/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Recruitment/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "RECRUIT_ID,POSITION,JOB_LOCATION,SKILLS_REQ,JOB_DESC,REQ_CGPA")] RECRUITMENT rECRUITMENT)
//        {
//            if (ModelState.IsValid)
//            {
                
               
//                rECRUITMENT.CREATED_DATE = DateTime.Now;

//                db.RECRUITMENTs.Add(rECRUITMENT);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(rECRUITMENT);
//        }

//        // GET: Recruitment/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RECRUITMENT rECRUITMENT = db.RECRUITMENTs.Find(id);
//            if (rECRUITMENT == null)
//            {
//                return HttpNotFound();
//            }
//            return View(rECRUITMENT);
//        }

//        // POST: Recruitment/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(/*[Bind(Include = "RECRUIT_ID,POSITION,JOB_LOCATION,SKILLS_REQ,JOB_DESC,REQ_CGPA,CREATED_DATE")]*/ RECRUITMENT rECRUITMENT, int recruit_id)
//        {
//            var data = db.RECRUITMENTs.FirstOrDefault(x => x.RECRUIT_ID == recruit_id);
//            if (data != null)
//            {
//                data.POSITION = rECRUITMENT.POSITION;
//                data.JOB_LOCATION = rECRUITMENT.JOB_LOCATION;
//                data.SKILLS_REQ = rECRUITMENT.SKILLS_REQ;
//                data.JOB_DESC = rECRUITMENT.JOB_DESC;
//                data.REQ_CGPA = rECRUITMENT.REQ_CGPA;
//                data.CREATED_DATE = rECRUITMENT.CREATED_DATE;
//                rECRUITMENT.MODIFIED_DATE = DateTime.Now;
//                data.MODIFIED_DATE = rECRUITMENT.MODIFIED_DATE;
                
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            else
//            return View(rECRUITMENT);
//        }    
        

//        // GET: Recruitment/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RECRUITMENT rECRUITMENT = db.RECRUITMENTs.Find(id);
//            if (rECRUITMENT == null)
//            {
//                return HttpNotFound();
//            }
//            return View(rECRUITMENT);
//        }

//        // POST: Recruitment/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            RECRUITMENT rECRUITMENT = db.RECRUITMENTs.Find(id);
//            db.RECRUITMENTs.Remove(rECRUITMENT);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
