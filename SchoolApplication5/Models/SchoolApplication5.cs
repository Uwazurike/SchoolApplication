using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication5
{
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
    }

    public class CourseMetaData
    {
        [DisplayName("Course")]
        public int CourseID { get; set; }

        [DisplayName("Course")]
        [Required(ErrorMessage = "Please enter a Course Name")]
        [MaxLength(150, ErrorMessage = "Course Name can't be more than 150 characters")]
        public string CourseName { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "A description is required")]
        [MaxLength(150, ErrorMessage = "Keep Course Descriptions under 150 characters")]
        public string CourseDescription { get; set; }

        [DisplayName("Category")]
        public Nullable<int> CourseCategory { get; set; }
    }

    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {
    }

    public class StudentMetaData
    {
        [DisplayName("Student")]
        public int StudentID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter a Student Name")]
        [MaxLength(150, ErrorMessage = "Student Name can't be more than 150 characters")]
        public string StudentName { get; set; }
    }

    [MetadataType(typeof(EnrollmentRecordMetaData))]
    public partial class EnrollmentRecord
    {
    }

    public class EnrollmentRecordMetaData
    {
        [DisplayName("Enrollment")]
        public int EnrollmentID { get; set; }

        [DisplayName("Student")]
        public int EnrollmentStudent { get; set; }

        [DisplayName("Course")]
        public int EnrollmentCourse { get; set; }
    }

    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
    }

    public class CategoryMetaData
    {
        [DisplayName("Category")]
        public int CategoryID { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Please enter a Category Name")]
        [MaxLength(150, ErrorMessage = "Category Name can't be more than 150 characters")]
        public string CategoryName { get; set; }
    }
}