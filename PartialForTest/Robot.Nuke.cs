using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForPartial
{
    public partial class Robot
    {
        public void Nuke()
        {
            Console.WriteLine($"{Name}: Nuclear launch detected!");
        }
    }
}
