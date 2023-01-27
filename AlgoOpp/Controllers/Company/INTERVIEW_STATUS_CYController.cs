using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlgoOpp.Models;

namespace AlgoOpp.Controllers.Company
{
    public class INTERVIEW_STATUS_CYController : Controller
    {
        TechathonDB_user11Entities5 db = new TechathonDB_user11Entities5();
        TechathonDB_user11Entities6 db2 = new TechathonDB_user11Entities6();
        TechathonDB_user11Entities2 db1 = new TechathonDB_user11Entities2();


        // GET: INTERVIEW_STATUS_CY
        public ActionResult Index()
        {
            var session = (AlgoOpp.Models.Membership)Session["model"];
            var data = session.Email_id;
            var data2 = db1.COMPANY_DETAILS.FirstOrDefault(x => x.EMAIL_ID == data.ToString());
            var data3 = data2.EST_ID;
            return View(db.INTERVIEW_STATUS_CY.Where(x => x.EST_ID_CY == data3).ToList());
        }

        // GET: INTERVIEW_STATUS_CY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INTERVIEW_STATUS_CY iNTERVIEW_STATUS_CY = db.INTERVIEW_STATUS_CY.Find(id);
            if (iNTERVIEW_STATUS_CY == null)
            {
                return HttpNotFound();
            }
            return View(iNTERVIEW_STATUS_CY);
        }

        // GET: INTERVIEW_STATUS_CY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: INTERVIEW_STATUS_CY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "INTERVIEW_ID,STUD_NAME,EMAIL_ID,MOBILE,DEPARTMENT,YEAR,CGPA,APTITUDE_ROUND,TECHNICAL_ROUND,HR_ROUND,APP_STATUS,STUD_ID,EST_ID_CY,EST_ID_CL,NOTIFY_ID_CL,NOTIFY_ID_CY,RECRUIT_ID_CY")] INTERVIEW_STATUS_CY iNTERVIEW_STATUS_CY)
        {
            if (ModelState.IsValid)
            {
                db.INTERVIEW_STATUS_CY.Add(iNTERVIEW_STATUS_CY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNTERVIEW_STATUS_CY);
        }

        // GET: INTERVIEW_STATUS_CY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INTERVIEW_STATUS_CY iNTERVIEW_STATUS_CY = db.INTERVIEW_STATUS_CY.Find(id);
            if (iNTERVIEW_STATUS_CY == null)
            {
                return HttpNotFound();
            }
            return View(iNTERVIEW_STATUS_CY);
        }

        // POST: INTERVIEW_STATUS_CY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "INTERVIEW_ID,STUD_NAME,EMAIL_ID,MOBILE,DEPARTMENT,YEAR,CGPA,APTITUDE_ROUND,TECHNICAL_ROUND,HR_ROUND,APP_STATUS,STUD_ID,EST_ID_CY,EST_ID_CL,NOTIFY_ID_CL,NOTIFY_ID_CY,RECRUIT_ID_CY")] INTERVIEW_STATUS_CY iNTERVIEW_STATUS_CY, INTERVIEW_STATUS_CL interview2, int id)
        {
            var data2 = db.INTERVIEW_STATUS_CY.FirstOrDefault(x => x.INTERVIEW_ID == id); 
            var data = db2.INTERVIEW_STATUS_CL.FirstOrDefault(x => x.INTERVIEW_ID_CY == iNTERVIEW_STATUS_CY.INTERVIEW_ID);

            if (ModelState.IsValid)
            {
                data2.APTITUDE_ROUND = iNTERVIEW_STATUS_CY.APTITUDE_ROUND;
                data2.TECHNICAL_ROUND = iNTERVIEW_STATUS_CY.TECHNICAL_ROUND;
                data2.HR_ROUND = iNTERVIEW_STATUS_CY.HR_ROUND;
                
                db.SaveChanges();

                data.APTITUDE_ROUND = data2.APTITUDE_ROUND;
                data.TECHNICAL_ROUND = data2.TECHNICAL_ROUND;
                data.HR_ROUND = data2.HR_ROUND;

                db2.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(iNTERVIEW_STATUS_CY);
        }

        // GET: INTERVIEW_STATUS_CY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INTERVIEW_STATUS_CY iNTERVIEW_STATUS_CY = db.INTERVIEW_STATUS_CY.Find(id);
            if (iNTERVIEW_STATUS_CY == null)
            {
                return HttpNotFound();
            }
            return View(iNTERVIEW_STATUS_CY);
        }

        // POST: INTERVIEW_STATUS_CY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INTERVIEW_STATUS_CY iNTERVIEW_STATUS_CY = db.INTERVIEW_STATUS_CY.Find(id);
            db.INTERVIEW_STATUS_CY.Remove(iNTERVIEW_STATUS_CY);
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
    }
}
