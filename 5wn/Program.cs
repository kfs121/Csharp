using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5wn
{
    class Program
    {
        const int MAX_LIST = 5;
        const int MAX_NUMBER = 100;
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            bool keepGoing = true;
            GetRandNum(list);

            while (keepGoing)
            {
                keepGoing = RemoveList(list, InputIndex(list));
            }
        }


        static void PrintList(List<int> list)
        {
            Console.WriteLine($"[{string.Join(", ", list)}]");
        }

        static int InputIndex(List<int> list)
        {
            string numIndex;
            while (true)
            {
                PrintList(list);
                Console.Write("Index to remove: ");
                numIndex = Console.ReadLine();
                if (int.TryParse(numIndex, out int result) && (result >= 0 && result < list.Count))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Wrong index. Try Again.");
                }
            }
        }

        static bool RemoveList(List<int> list, int index)
        {
            list.RemoveAt(index);

            if (list.Count == 0)
            {
                return false;
            }
            return true;
        }

        static void GetRandNum(List<int> list)
        {
            Random rand = new Random();

            for(int i = 0; i < MAX_LIST; i++)
            {
                list.Add(rand.Next(0, MAX_NUMBER));
            }
        }
    }
}
