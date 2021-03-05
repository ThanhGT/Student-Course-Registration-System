////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: StudentRepository.cs
//Author : Thanh Tran
//Description : A model container for Student objects(?)
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tran_991515427_LABS.Models
{
    public class StudentRepository
    {
        // Following code is used to make this class iterable/enumerable
        private static List<StudentResponse> responses = new List<StudentResponse>();
        public static IEnumerable<StudentResponse> Response => responses;
        // Simply add a Student to the list
        public static void AddResponse(StudentResponse response)
        {
            responses.Add(response);
        }
    }
}