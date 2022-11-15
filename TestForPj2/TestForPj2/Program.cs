using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prj_1
{
    class Program
    {
        const int PLANE_SIZE = 2;
        const string PLANE = ">-0-<";
        const string REMOVE_PLANE = "     ";

        enum EKeyCode
        {
            Left =0x25,
            Up,
            Right,
            Down
        }

        static readonly int[] PLANE_START_POSITION = { (int)MapSize.x / 2, (int)MapSize.y / 2 };
        enum MapSize
        {
            x = 58,
            y = 20
        }

        static void Main(string[] args)
        {

            int[] planeXY = PLANE_START_POSITION;

            Console.CursorVisible = false;
            PrintFieldConsole();
            DrawConsole(planeXY, PLANE, PLANE_SIZE);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                    DrawConsole(planeXY, REMOVE_PLANE, PLANE_SIZE);

                    if (consoleKey.Key == ConsoleKey.LeftArrow && planeXY[0] - PLANE_SIZE > 1 )
                    {
                        planeXY[0]--;
                    }
                    else if (consoleKey.Key == ConsoleKey.RightArrow && planeXY[0] + PLANE_SIZE < (int)MapSize.x)
                    {
                        planeXY[0]++;
                    }
                    else if (consoleKey.Key == ConsoleKey.UpArrow && planeXY[1] > 0)
                    {
                        planeXY[1]--;
                    }
                    else if (consoleKey.Key == ConsoleKey.DownArrow && planeXY[1] < (int)MapSize.y - 2)
                    {
                        planeXY[1]++;
                    }

                    DrawConsole(planeXY, PLANE, PLANE_SIZE);
                }
            }
        }

        static void PrintFieldConsole()        // 기능 추가시 Get함수로 바꾸고, 배열 프린트 하는 함수 추가하기 
        {
            char x = ' ';
            for (int i = 0; i < (int)MapSize.y; i++)
            {
                Console.Write("|");
                if (i == (int)MapSize.y - 1)
                {
                    x = '-';
                }
                for (int j = 0; j < (int)MapSize.x; j++)
                {
                    Console.Write(x);
                }
                Console.WriteLine("|");
            }
        }

        static void DrawConsole(int[] xY, string shape, int size)
        {
            Console.SetCursorPosition(xY[0] - size, xY[1]);
            Console.Write(shape);
        }
    }
}
