using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForPartial
{
    public partial class Robot
    {
        public Robot(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void ShootLaserBeam()
        {
            Console.WriteLine($"{Name} shooting laser beam!");
        }

        public void ShootMissiles()
        {
            Console.WriteLine($"{Name} shooting missiles!");
        }
    }
}
