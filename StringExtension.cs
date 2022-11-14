using System;
using System.Text;

namespace ConsoleApp12
{
    static class StringExtension
    {
        public static string Reverse(this string input)
        {
            StringBuilder stb = new StringBuilder();
            for(int i = input.Length - 1; i >= 0; i--)
            {
                stb.Append(input[i]);
            }

            return stb.ToString();
        }
    }
}
