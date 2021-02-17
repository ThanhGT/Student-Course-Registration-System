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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //post responses into repository
        [HttpPost] //post method
        public ViewResult StudentForm(StudentResponse studentResponse)
        {
            // checks if it was possible to bind the incoming values from the request to the model 
            // correctly and check if any specific validation rules were violated
            if (ModelState.IsValid)
            {
                //store the responses from the guests
                studentRepository.AddResponse(studentResponse);

                //pass responses to the Razer View page "SummeryPage")
                return View("SummaryPage", studentResponse);
            }
            else
            {
                //return to view if responses are not valid
                return View();
            }
        }

        //load the studentForm
        [HttpGet]
        public ViewResult StudentForm()
        {
            return View();
        }

        // post responses in repository
        [HttpPost]
        public ViewResult CourseForm(CourseResponse courseResponse)
        {
            // checks if it was possible to bind the incoming values from the request to the model 
            // correctly and check if any specific validation rules were violated
            if (ModelState.IsValid)
            {
                //store the responses from the guests
                courseRepository.AddResponse(courseResponse);

                //pass responses to the Razer View page "SummeryPage")
                return View("SummaryPage", courseResponse);
            }
            else
            {
                //return to view if responses are not valid
                return View();
            }
        }

        //load the courseform
        [HttpGet]
        public ViewResult CourseForm()
        {
            return View();
        }

        public IActionResult Index()
        {
            ViewBag.WelcomeTitle = "TT's Student Course Registration System";
            return View("Welcome");
        }

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
