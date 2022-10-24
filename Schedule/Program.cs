using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Schedule> mySchedule = new List<Schedule>();

            mySchedule.Add(new Schedule(DayOfWeek.Monday, new DateTime(1, 1, 1, 10, 0, 0), "Meeting with my boss"));
            mySchedule.Add(new Schedule(DayOfWeek.Tuesday, new DateTime(1, 1, 1, 13, 0, 0), "Presentation"));
            mySchedule.Add(new Schedule(DayOfWeek.Wednesday, new DateTime(1, 1, 1, 16, 0, 0), "Wrap-up"));
            mySchedule.Add(new Schedule(DayOfWeek.Sunday, new DateTime(1, 1, 1, 15, 0, 0), "Sunday schedule"));
            mySchedule.Add(new Schedule(DayOfWeek.Thursday, new DateTime(1, 1, 1, 19, 0, 0), "19h schedule"));

            foreach (Schedule s in mySchedule)
            {
                Console.WriteLine($"{s.MyDayOfWeek} {s.MyTime.ToString("t")} : {s.MyMemo}");
            }

            Console.ReadKey();
        }
    }
}
