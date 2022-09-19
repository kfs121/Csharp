using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class Program
    {
        const int ASCII_INTERVAL = 32;
        enum Ascii
        {
            A = 65,
            a = 97,
            Z = 90
        }
        
        static void Main(string[] args)
        {
            string inputString;
            while (true)
            {
                
                Console.Write("Input Sentence: ");
                inputString = Console.ReadLine();

                if(inputString == "Q")
                {
                    return;
                }

                CorrectSentence(inputString, out string outputString);
                Console.WriteLine("Corrected to: " + outputString);
            }
        }



        static void CorrectSentence(string inputString, out string outputString)
        {
            StringBuilder strBuilder = new StringBuilder(inputString.Length);
            strBuilder.Append(inputString);
            if(inputString[0] >= (int)Ascii.a)
            {
                strBuilder[0] = (char)(strBuilder[0] - ASCII_INTERVAL);
            }

            for(int i = 1; i < strBuilder.Length; i++)
            {
                if(strBuilder[i] >= (int)Ascii.A && strBuilder[i] <= (int)Ascii.Z)
                {
                    strBuilder[i] = (char)(strBuilder[i] + ASCII_INTERVAL);
                }
            }
            if (strBuilder[strBuilder.Length - 1] != '.')
            {
                strBuilder.Append('.');
            }

            outputString = strBuilder.ToString();
        }
    }
}
