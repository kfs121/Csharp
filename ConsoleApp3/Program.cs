using System;



using System.Collections.Generic;



using System.Linq;



using System.Text;



using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string korScore;
            string mathScore;

            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Korean Score: ");
            korScore = Console.ReadLine();
            Console.Write("Math Score: ");
            mathScore = Console.ReadLine();

            PrintReport(name, korScore, mathScore);

            Console.ReadKey();
        }

        static string GetGrade(int score)
        {
            string grade;

            if (score >= 90)
            {
                grade = "A";
            }
            else if (score >= 80)
            {
                grade = "B";
            }
            else if (score >= 70)
            {
                grade = "C";

            }
            else if (score >= 60)
            {
                grade = "D";
            }
            else
            {
                grade = "F";
            }

            return grade;
        }

        static void PrintReport(string name, string korScore, string mathScore)
        {
            int korScoreInt = int.Parse(korScore);
            int mathScoreInt = int.Parse(mathScore);

            double average = (korScoreInt + (double)mathScoreInt) / 2;

            korScore = GetGrade(korScoreInt);
            mathScore = GetGrade(mathScoreInt);

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|{0,-9}|{1,-9}|{2,-9}|{3,-9}|", "Name", "Korean", "Math", "Average");
            Console.WriteLine("|{0,-9}|{1,-9}|{2,-9}|{3,-9}|", name, korScore, mathScore, average);
            Console.WriteLine("-----------------------------------------");
        }
    }
}