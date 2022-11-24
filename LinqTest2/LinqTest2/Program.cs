using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqTest2
{
    class Program
    {

        const string PATH = @".\Weapons2.csv";
        static void Main(string[] args)
        {
            string[] csvLines = File.ReadAllLines(PATH);
            List<Weapon> weaponList = new List<Weapon>();
            int select;

            for (int i = 1; i < csvLines.Length; i++)
            {
                char[] seperators = { ',' };
                string[] columns = csvLines[i].Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                weaponList.Add(new Weapon(columns[0], (EType)Enum.Parse(typeof(EType), columns[1]),
                    columns[2], int.Parse(columns[3]), int.Parse(columns[4]), int.Parse(columns[5]),
                    float.Parse(columns[6])));
            }

            while (true)
            {
                select = GetMenuSelect();
                switch (select)
                {
                    case 1:
                        Console.Write(" 찾을 단어 :");
                        SearchList(Console.ReadLine(), weaponList);
                        break;

                    case 2:
                        Console.Write(" 찾을 레벨 :");
                        SearchList(int.Parse(Console.ReadLine()), weaponList);
                        break;
                    case 4:
                        return;
                }
                Console.WriteLine();
            }
        }

        static int GetMenuSelect()
        {
            Console.WriteLine("1. 이름 찾기");
            Console.WriteLine("2. 레벨 찾기");
            Console.WriteLine("4. 종료");
            Console.Write("무엇을 선택하시겠습니까? ");

            return int.Parse(Console.ReadLine());
        }

        static void SearchList(String wordForSearch, List<Weapon> list)
        {
            List<Weapon> tempList = new List<Weapon>();
            Console.WriteLine($"\"{wordForSearch}\"이 포함된 이름을 출력합니다.");
            tempList = list.Where(m => m.Name.Contains(wordForSearch)).ToList();
            if (tempList.Count == 0)
            {
                Console.WriteLine("데이터가 없습니다.");
                return;
            }
            PrintWeapons(tempList);
        }

        static void SearchList(int level, List<Weapon> weaponList)
        {
            List<Weapon> tempList = new List<Weapon>();

            Console.WriteLine($"\"{level}\"레벨 이상을 출력합니다.");
            tempList = weaponList.Where(m => m.Level >= level).ToList();
            if (tempList.Count == 0)
            {
                Console.WriteLine("데이터가 없습니다.");
                return;
            }
            PrintWeapons(tempList);
        }

        static void PrintWeapons(List<Weapon> weaponList)
        {
            Console.WriteLine($"  {"ID",-6}{"Name",-11}{"Level",-6}{"Power"}");
            foreach (Weapon weapon in weaponList)
            {
                Console.WriteLine($"  {weapon.Id,-6}{weapon.Name,-11}{weapon.Level,-6}{weapon.Power}");
            }
        }
    }
}