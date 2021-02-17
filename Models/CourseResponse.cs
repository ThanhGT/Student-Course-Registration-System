using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tran_991515427_LABS.Models
{
    public class CourseResponse
    {
        [Required(ErrorMessage = "Please enter a course code")]
        // getter and setter for first name
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Please enter a course name")]
        // getter and setter for the last name
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Please enter enrolled student name")]
        // getter and setter for courses
        public string EnrolledStudents { get; set; }
        [Required(ErrorMessage = "Please enter number of credits")]
        // getter and setter for student number
        public string NumberOfCredits { get; set; }
    }
}
