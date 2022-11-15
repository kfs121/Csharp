using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForPartial
{


    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot("Taekwon V");

            Console.WriteLine(robot.Name);

            robot.ShootLaserBeam();
            robot.ShootMissiles();
            robot.Nuke();

            Console.ReadKey();
        }
    }
}
