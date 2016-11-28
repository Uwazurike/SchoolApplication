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
    public class CoursesController : Controller
    {
        private SchoolApp4Entities db = new SchoolApp4Entities();

        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Category);
            return View(courses.ToList());
        }

        public ActionResult Details(int? id)
        {
            var history = from r in db.EnrollmentRecords
                          join m in db.Courses
                          on r.Course.CourseName equals m.CourseName
                          where r.EnrollmentCourse == id
                          select new SchoolApplication5.Models.SchoolViewModel2
                          {
                              StudentID = r.Student.StudentID,
                              StudentName = r.Student.StudentName,
                              CourseID = m.CourseID,
                              CourseName = m.CourseName,
                              CourseDescription = m.CourseDescription,
                              CategoryName = m.Category.CategoryName
                          };
            return View(history); ;
        }

        public ActionResult Create()
        {
            ViewBag.CourseCategory = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,CourseName,CourseDescription,CourseCategory")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseCategory = new SelectList(db.Categories, "CategoryID", "CategoryName", course.CourseCategory);
            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseCategory = new SelectList(db.Categories, "CategoryID", "CategoryName", course.CourseCategory);
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,CourseDescription,CourseCategory")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseCategory = new SelectList(db.Categories, "CategoryID", "CategoryName", course.CourseCategory);
            return View(course);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
