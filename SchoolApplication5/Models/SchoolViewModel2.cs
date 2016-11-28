using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;

namespace SchoolApplication5.Models
{
    public class SchoolViewModel2
    {
        [DisplayName("Course")]
        public int CourseID { get; set; }

        [DisplayName("Course")]
        public string CourseName { get; set; }

        [DisplayName("Description")]
        public string CourseDescription { get; set; }

        [DisplayName("Student")]
        public int StudentID { get; set; }

        [DisplayName("Name")]
        public string StudentName { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [DisplayName("Enrolled")]
        public int EnrollmentID { get; set; }
        [DisplayName("Course")]
        public int EnrollmentCourse { get; set; }
        [DisplayName("Student")]
        public int EnrollmentStudent { get; set; }
    }
}