using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keep = true;
            while (keep)
            {
                string exp = InputExp();
                Partition(exp);
            }
        }



        static string InputExp()
        {
            Console.Write("Enter equation(Q to quit): ");
            string exp = Console.ReadLine();
            if (exp == "Q")
            {
                Environment.Exit(0);
            }
            return exp;
        }

        static void Partition(string exp)
        {
            string[] expPartition = null;
            char artimatic = ' ';

            if (exp.IndexOf('+') > 0)
            {
                expPartition = exp.Split('+');
                artimatic = '+';
            }
            else if (exp.IndexOf('-') > 0)
            {
                expPartition = exp.Split('-');
                artimatic = '-';
            }
            else if (exp.IndexOf('*') > 0)
            {
                expPartition = exp.Split('*');
                artimatic = '*';
            }
            else if (exp.IndexOf('/') > 0)
            {
                expPartition = exp.Split('/');
                artimatic = '/';
            }

            Calculate(expPartition, artimatic);


        }

        static void Calculate(string[] exp, char artimatic)
        {
            int num1 = int.Parse(exp[0]);
            int num2 = int.Parse(exp[1]);
            float result = 0;

            switch (artimatic)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = (float)num1 / num2;
                    break;
            }

            Console.WriteLine($"{num1} {artimatic} {num2} = {result}\n");
        }
    }
}


