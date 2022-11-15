using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseCode courseCode1 = new CourseCode(ESubject.CSHA, 1001);
            Console.WriteLine($"{courseCode1.Subject} {courseCode1.Number}");
            CourseCode courseCode2 = CourseCode.Parse("JAVA1001");
            Console.WriteLine($"{courseCode2.Subject} {courseCode2.Number}");
            CourseCode courseCode3;
            bool bParsed = CourseCode.TryParse("CSHA10002", out courseCode3);
            Console.WriteLine($"Parsed: {bParsed}");
            CourseCode courseCode4;
            bParsed = CourseCode.TryParse("CSHA1002", out courseCode4);
            Console.WriteLine($"Parsed: {bParsed}");
            Console.WriteLine($"{courseCode4.Subject} {courseCode4.Number}");
        }
    }
}