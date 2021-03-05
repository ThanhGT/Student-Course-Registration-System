using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tran_991515427_LABS.Models;

namespace Tran_991515427_LABS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // CURRENT's construct
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ViewResult StudentForm(StudentResponse studentResponse)
        {
            // correctly and check if any specific validation rules (pre-conditions) were violated
            if (ModelState.IsValid)
            {
                //store the responses from the students
                StudentRepository.AddResponse(studentResponse);

                // For void-safety, instead of using the studentResponse param, let's just get a pointer to the newly added student and...
                StudentResponse studentPtr = StudentRepository.Response.Last();

                // if the student is valid, also add that student to the respective course and then...
                foreach (String studentCourse in studentPtr.Courses)
                {
                    // try and match it with the respective course in the Course Repo (bad performance O^n2 but i'm tired so too bad...) then...
                    foreach (CourseResponse courseResp in CourseRepository.Response)
                    {
                        // if we get a match, add that student to the course in the course repo
                        if (courseResp.CourseName.Equals(studentCourse))
                        {
                            courseResp.addStudent(studentPtr);
                        }
                    }
                }
                return View("Thanks", studentResponse);
            }
            else
            {
                //return to view if responses are not valid
                return View();
            }
        }

        //load the studentForm. Nuff' said.
        [HttpGet]
        public ViewResult StudentForm()
        {
            return View();
        }

        // View for the Summary Page. Requires the Course Repo as param for its model.
        public ViewResult SummaryPage()
        {
            return View(CourseRepository.Response);
        }

        // Drops a student based on the student number and course code. Probably better than passing the object reference/pointers as params...
        public ViewResult DropStudent(String studentNumber, String dropCourseCode)
        {
            // Look for the appropriate course in the repo
            foreach (CourseResponse courseResp in CourseRepository.Response)
            {
                // once found, remove the appropriate student from that course code by calling the removeStudent code in the CourseResponse class
                if (dropCourseCode.Equals(courseResp.CourseCode))
                {
                    courseResp.removeStudent(studentNumber);
                }
            }
            // Return the SummaryPage (simulates refreshing the page)
            return View("SummaryPage", CourseRepository.Response);
        }

        // Get the View on Return to Home
        public ViewResult Welcome()
        {
            ViewBag.WelcomeTitle = "TT's Student Course Registration System";
            return View();
        }

        // Basically the init(). Only call this once!
        public IActionResult Index()
        {
            // Hardcode the list of courses here and add them to the Course Repo. Should match the option value Course Names in the StudentForm View
            CourseRepository.AddResponse(new CourseResponse() { CourseCode = "SPM", CourseName = "Software Process Management", NumberOfCredits = 3 } );
            CourseRepository.AddResponse(new CourseResponse() { CourseCode = "AJF", CourseName = "Advanced Java Frameworks", NumberOfCredits = 3 });
            CourseRepository.AddResponse(new CourseResponse() { CourseCode = "CAP", CourseName = "Capstone Prototype", NumberOfCredits = 6 });
            CourseRepository.AddResponse(new CourseResponse() { CourseCode = "3DG", CourseName = "3D Game Programming Foundations", NumberOfCredits = 3 });
            CourseRepository.AddResponse(new CourseResponse() { CourseCode = "GMP", CourseName = "Game Engineering Principles", NumberOfCredits = 3 });
            CourseRepository.AddResponse(new CourseResponse() { CourseCode = "AAD", CourseName = "Android Application Development", NumberOfCredits = 3 });
            CourseRepository.AddResponse(new CourseResponse() { CourseCode = "MAD", CourseName = "Mobile iOS Application Development", NumberOfCredits = 3 });
            CourseRepository.AddResponse(new CourseResponse() { CourseCode = "IIE", CourseName = "Innovation: From Idea to Execution", NumberOfCredits = 4 });

            ViewBag.WelcomeTitle = "TT's Student Course Registration System";
            return View("Welcome");
        }

        // Why do I need this again?
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
