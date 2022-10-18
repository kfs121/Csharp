using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Position position = new Position();
            position.PrintPosition();
            position.MoveDown();
            position.MoveRight();
            position.PrintPosition();
            position.MoveUp();
            position.MoveLeft();
            position.PrintPosition();

            Console.ReadKey();
        }
    }

    class Position
    {
        private int x, y;
        
        public Position()
        {
            x = 100;
            y = 100;
        }

        public void PrintPosition()
        {
            Console.Out.WriteLine($"Position: ({x}, {y})");
        }

        public void MoveDown()
        {
            y--;
            Console.WriteLine("Moving down");
        }

        public void MoveUp()
        {
            y++;
            Console.WriteLine("Moving up");

        }

        public void MoveLeft()
        {
            x--;
            Console.WriteLine("Moving left");

        }

        public void MoveRight()
        {
            x++;
            Console.WriteLine("Moving right");

        }
    }
}
