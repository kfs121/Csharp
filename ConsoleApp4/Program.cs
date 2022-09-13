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
            Console.Write("How many students? ");
            int num_stu = int.Parse(Console.ReadLine());

            string[] names = new string[num_stu];
            string[] korScores = new string[num_stu];
            string[] mathScores = new string[num_stu];

            InputReport(names, korScores, mathScores);
            PrintReport(names, korScores, mathScores);

            Console.ReadKey();
        }




        static void PrintReport(string[] names, string[] korScores, string[] mathScores)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|{0,-9}|{1,-9}|{2,-9}|{3,-9}|", "Name", "Korean", "Math", "Average");

            for (int i = 0; i < names.Length; i++)
            {
                int korScoreInt = int.Parse(korScores[i]);
                int mathScoreInt = int.Parse(mathScores[i]);
                double average = (korScoreInt + (double)mathScoreInt) / 2;

                korScores[i] = GetGrade(korScoreInt);
                mathScores[i] = GetGrade(mathScoreInt);

                Console.WriteLine("|{0,-9}|{1,-9}|{2,-9}|{3,-9}|", names[i], korScores[i], mathScores[i], average);
            }

            Console.WriteLine("-----------------------------------------");
        }




        static void InputReport(string[] names, string[] korScores, string[] mathScores)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("Name: ");
                names[i] = Console.ReadLine();
                Console.Write("Korean Score: ");
                korScores[i] = Console.ReadLine();
                Console.Write("Math Score: ");
                mathScores[i] = Console.ReadLine();
            }
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
    }


}

