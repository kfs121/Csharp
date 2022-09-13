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
            string[] kor_scores = new string[num_stu];
            string[] math_scores = new string[num_stu];

            double[] averages = new double[num_stu];

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("Name: ");
                names[i] = Console.ReadLine();
                Console.Write("Korean Score: ");
                kor_scores[i] = Console.ReadLine();
                Console.Write("Math Score: ");
                math_scores[i] = Console.ReadLine();

                int kor_score = int.Parse(kor_scores[i]);
                int math_score = int.Parse(math_scores[i]);

                if (kor_score >= 90)
                {
                    kor_scores[i] = "A";
                }
                else if (kor_score >= 80)
                {
                    kor_scores[i] = "B";
                }
                else if (kor_score >= 70)
                {
                    kor_scores[i] = "C";
                }
                else if (kor_score >= 60)
                {
                    kor_scores[i] = "D";
                }
                else
                {
                    kor_scores[i] = "F";
                }


                if (math_score >= 90)
                {
                    math_scores[i] = "A";
                }
                else if (math_score >= 80)
                {
                    math_scores[i] = "B";
                }
                else if (math_score >= 70)
                {
                    math_scores[i] = "C";
                }
                else if (math_score >= 60)
                {
                    math_scores[i] = "D";
                }
                else
                {
                    math_scores[i] = "F";
                }

                averages[i] = (kor_score + (double)math_score) / 2;
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|{0,-9}|{1,-9}|{2,-9}|{3,-9}|", "Name", "Korean", "Math", "Average");

            for (int i = 0; i < names.Length; i++) {
                Console.WriteLine("|{0,-9}|{1,-9}|{2,-9}|{3,-9}|", names[i], kor_scores[i], math_scores[i], averages[i]);
            }

            Console.WriteLine("-----------------------------------------");
            Console.Read();
        }
    }
}