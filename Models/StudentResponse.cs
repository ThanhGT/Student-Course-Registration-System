using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tran_991515427_LABS.Models
{
    public class StudentResponse
    {
        [Required(ErrorMessage = "Please enter your first name")]
        // getter and setter for first name
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        // getter and setter for the last name
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your student number")]
        // getter and setter for student number
        public string StudentNumber { get; set; }
        [Required(ErrorMessage = "Please select the courses you are enrolled in")]
        // getter and setter for courses
        public bool? Courses { get; set; }
    }
}
