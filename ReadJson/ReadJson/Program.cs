using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadJson
{
    class Program
    {
        const string FILE_NAME = "Swords.json";
        static void Main(string[] args)
        {
            List<Sword> swords = new List<Sword>();
            string input = File.ReadAllText(FILE_NAME);

            swords = JsonConvert.DeserializeObject<List<Sword>>(input);

            foreach ( Sword sword in swords)
            {
                Console.WriteLine($"{sword.Name}");
            }
        }
    }
}
