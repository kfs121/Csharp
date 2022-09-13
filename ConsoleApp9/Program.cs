using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        const double subNum = 2.0;
        enum Grade 
        {
            A = 90,
            B = 80,
            C = 70,
            D = 60     
        };

        static void Main(string[] args)
        {
            int stuNum = InputStuNum();
            String[] names = new String[stuNum];
            int[] math = new int[stuNum];
            int[] kor = new int[stuNum];

            InputScore(names, math, kor);
            PrintScore(names, math, kor);

            Console.ReadKey();
        }

        static int InputStuNum() 
        {
            Console.Write("How many students? ");
            return int.Parse(Console.ReadLine());
        }

        static void InputScore(String[] names, int[] math, int[] kor) 
        {
            for (int i = 0; i < names.Length; i++) 
            {
                Console.Write("Name: ");
                names[i] = Console.ReadLine();

                Console.Write("Korean Score: ");
                kor[i] = int.Parse(Console.ReadLine());

                Console.Write("Math Score: ");
                math[i] = int.Parse(Console.ReadLine());

                Console.WriteLine();
            }
        }

        static char GetGrade(int score) 
        {
            if (score >= (int)Grade.A)
            {
                return 'A';
            }
            else if (score >= (int)Grade.B) 
            {
                return 'B';
            }
            else if (score >= (int)Grade.C)
            {
                return 'C';
            }
            else
            {
                return 'D';
            }
        }

        static void PrintScore(String[] names, int[] math, int[] kor) 
        {
            double averMath = GetArrAver(math, math.Length);
            double averKor = GetArrAver(kor, kor.Length);
            
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine($"|{"Name",-9}|{"Korean",-9}|{"Math",-9}|{"Average",-9}|");
            for (int i = 0; i < names.Length; i++) 
            {
                Console.WriteLine($"|{names[i],-9}|{GetGrade(kor[i]),-9}|{GetGrade(math[i]),-9}|{ ((kor[i] + math[i]) / subNum) ,-9:f1}|");
            }
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine($"|{"Average",-9}|{averKor,-9:f1}|{averMath,-9:f1}|{(averKor + averMath) / subNum ,-9:f1}|");
            Console.WriteLine(" ---------------------------------------");
        }


        static double GetArrAver(int[] scores, int count) 
        {
            double averScore = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                averScore += scores[i];
            }

            return averScore / count;
        }
    }
}
