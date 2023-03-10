using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlgoOpp.Models;

namespace AlgoOpp.Controllers.College
{
    public class StudentDetailsController : Controller
    {
        private TechathonDB_user11Entities db1 = new TechathonDB_user11Entities();
        private StudentEntities db = new StudentEntities();

        // GET: StudentDetail
        public ActionResult Index()
        {//changed
            var session = (AlgoOpp.Models.Membership)Session["model"];
            var data = session.Email_id;
            var data2 = db1.COLLEGE_DETAILS.FirstOrDefault(x => x.EMAIL_ID == data.ToString());
            var data3 = Convert.ToInt32(data2.EST_ID);
            return View(db.STUDENT_DETAILS.Where(x => x.EST_ID == data3).ToList());
           
        }

        // GET: StudentDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_DETAILS sTUDENT_DETAILS = db.STUDENT_DETAILS.Find(id);
            if (sTUDENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_DETAILS);
        }

        // GET: StudentDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STUD_ID,NAME,EMAIL_ID,MOBILE,DEPARTMENT,YEAR,CGPA")] STUDENT_DETAILS sTUDENT_DETAILS)
        {
            if (ModelState.IsValid)
            {//changed
                var session = (AlgoOpp.Models.Membership)Session["model"];
                var data = session.Email_id;
                var data2 = db1.COLLEGE_DETAILS.FirstOrDefault(x => x.EMAIL_ID == data.ToString());
                sTUDENT_DETAILS.EST_NAME = data2.EST_NAME;
                sTUDENT_DETAILS.EST_ID = data2.EST_ID;
                db.STUDENT_DETAILS.Add(sTUDENT_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTUDENT_DETAILS);
        }

        // GET: StudentDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_DETAILS sTUDENT_DETAILS = db.STUDENT_DETAILS.Find(id);
            if (sTUDENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_DETAILS);
        }

        // POST: StudentDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STUD_ID,NAME,EMAIL_ID,MOBILE,DEPARTMENT,YEAR,CGPA")] STUDENT_DETAILS sTUDENT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTUDENT_DETAILS);
        }

        // GET: StudentDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_DETAILS sTUDENT_DETAILS = db.STUDENT_DETAILS.Find(id);
            if (sTUDENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_DETAILS);
        }

        // POST: StudentDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STUDENT_DETAILS sTUDENT_DETAILS = db.STUDENT_DETAILS.Find(id);
            db.STUDENT_DETAILS.Remove(sTUDENT_DETAILS);
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
