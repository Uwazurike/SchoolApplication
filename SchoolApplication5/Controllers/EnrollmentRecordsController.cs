using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolApplication5;

namespace SchoolApplication5.Controllers
{
    public class EnrollmentRecordsController : Controller
    {
        private SchoolApp4Entities db = new SchoolApp4Entities();

        public ActionResult Index()
        {
            var enrollmentRecords = db.EnrollmentRecords.Include(e => e.Course).Include(e => e.Student);
            return View(enrollmentRecords.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentRecord enrollmentRecord = db.EnrollmentRecords.Find(id);
            if (enrollmentRecord == null)
            {
                return HttpNotFound();
            }
            return View(enrollmentRecord);
        }

        public ActionResult Create()
        {
            ViewBag.EnrollmentCourse = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.EnrollmentStudent = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,EnrollmentStudent,EnrollmentCourse")] EnrollmentRecord enrollmentRecord)
        {
            if (ModelState.IsValid)
            {
                db.EnrollmentRecords.Add(enrollmentRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnrollmentCourse = new SelectList(db.Courses, "CourseID", "CourseName", enrollmentRecord.EnrollmentCourse);
            ViewBag.EnrollmentStudent = new SelectList(db.Students, "StudentID", "StudentName", enrollmentRecord.EnrollmentStudent);
            return View(enrollmentRecord);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentRecord enrollmentRecord = db.EnrollmentRecords.Find(id);
            if (enrollmentRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnrollmentCourse = new SelectList(db.Courses, "CourseID", "CourseName", enrollmentRecord.EnrollmentCourse);
            ViewBag.EnrollmentStudent = new SelectList(db.Students, "StudentID", "StudentName", enrollmentRecord.EnrollmentStudent);
            return View(enrollmentRecord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,EnrollmentStudent,EnrollmentCourse")] EnrollmentRecord enrollmentRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollmentRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnrollmentCourse = new SelectList(db.Courses, "CourseID", "CourseName", enrollmentRecord.EnrollmentCourse);
            ViewBag.EnrollmentStudent = new SelectList(db.Students, "StudentID", "StudentName", enrollmentRecord.EnrollmentStudent);
            return View(enrollmentRecord);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentRecord enrollmentRecord = db.EnrollmentRecords.Find(id);
            if (enrollmentRecord == null)
            {
                return HttpNotFound();
            }
            return View(enrollmentRecord);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollmentRecord enrollmentRecord = db.EnrollmentRecords.Find(id);
            db.EnrollmentRecords.Remove(enrollmentRecord);
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
