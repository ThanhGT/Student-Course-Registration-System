using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tran_991515427_LABS.Models
{
    public class courseRepository
    {
        private static List<CourseResponse> responses = new List<CourseResponse>();

        public static IEnumerable<CourseResponse> Responses => responses;

        public static void AddResponse(CourseResponse response)
        {
            responses.Add(response);
        }
    }
}