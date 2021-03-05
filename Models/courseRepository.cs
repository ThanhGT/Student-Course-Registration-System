////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: StudentRepository.cs
//Author : Thanh Tran
//Description : A model container for Course objects(?)
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tran_991515427_LABS.Models
{
    public class CourseRepository
    {
        // Following code is used to make this class iterable/enumerable
        private static List<CourseResponse> responses = new List<CourseResponse>();
        public static IEnumerable<CourseResponse> Response => responses;

        // Add a course to our list of courses
        public static void AddResponse(CourseResponse response)
        {
            responses.Add(response);
        }
    }
}