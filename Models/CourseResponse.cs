////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: Course.cs
//Author : Thanh Tran
//Description : Model class representing a Course Object.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tran_991515427_LABS.Models
{
    public class CourseResponse
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int NumberOfCredits { get; set; }

        public List<StudentResponse> EnrolledStudents = new List<StudentResponse>();

        // Simply add a student to the list of enrolled students for the CURRENT Course
        public void addStudent (StudentResponse student)
        {
            EnrolledStudents.Add(student);
        }

        // Simply removes the Student from the Enrolled Student List
        public void removeStudent(String studentNumberToRemove)
        {
            // I don't know how C#'s Find method works in Lists so I'll just search for the element myself.
            foreach(StudentResponse student in EnrolledStudents)
            {
                if (studentNumberToRemove.Equals(student.StudentNumber))
                {
                    EnrolledStudents.Remove(student);
                    // Don't forget to exit the loop.
                    break;
                }
            }
        }

        /*        [Required(ErrorMessage = "Please enter a course code")]
                public string CourseCode { get; set; }

                [Required(ErrorMessage = "Please enter a course name")]
                public string CourseName { get; set; }

                [Required(ErrorMessage = "Please enter the enrolled student name")]        
                public string EnrolledStudents { get; set; }

                [Required(ErrorMessage = "Please enter the number of credits")]
                public int NumberOfCredits { get; set; }*/
    }
}
