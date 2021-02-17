using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tran_991515427_LABS.Models
{
    public class studentRepository
    {
        private static List<StudentResponse> responses = new List<StudentResponse>();

        public static IEnumerable<StudentResponse> Response => responses;
        public static void AddResponse(StudentResponse response)
        {
            responses.Add(response);
        }
    }
}