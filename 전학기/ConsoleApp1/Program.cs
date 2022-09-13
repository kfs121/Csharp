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
            do
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Korean Score: ");
                string kor_sco = Console.ReadLine();
                Console.Write("Math Score: ");
                string math_sco = Console.ReadLine();

                int kor_score = int.Parse(kor_sco);
                int math_score = int.Parse(math_sco);

                if (kor_score >= 90)
                {
                    kor_sco = "A";
                }
                else if (kor_score >= 80)
                {
                    kor_sco = "B";
                }
                else if (kor_score >= 70)
                {
                    kor_sco = "C";
                }
                else if (kor_score >= 60)
                {
                    kor_sco = "D";
                }
                else
                {
                    kor_sco = "F";
                }


                if (math_score >= 90)
                {
                    math_sco = "A";
                }
                else if (math_score >= 80)
                {
                    math_sco = "B";
                }
                else if (math_score >= 70)
                {
                    math_sco = "C";
                }
                else if (math_score >= 60)
                {
                    math_sco = "D";
                }
                else
                {
                    math_sco = "F";
                }


                Console.WriteLine("-------------------------------");
                Console.WriteLine("|{0,-9}|{1,-9}|{2,-9}|", "Name", "Korean", "Math");
                Console.WriteLine("|{0,-9}|{1,-9}|{2,-9}|", name, kor_sco, math_sco);
                Console.WriteLine("-------------------------------");

                double sum = kor_score + math_score;

                Console.WriteLine($"Average = {sum / 2}");

                Console.Write("Again? (y/n) :");

            }while ( Console.ReadLine() == "y" ? true : false );
        }
    }
}