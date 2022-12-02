using System;

namespace Gacha2
{
    class Program
    {
        static void Main(string[] args)
        {
            GameHandler gameHandler = new GameHandler();
            string input;
            while (true)
            {
                string id;
                PrintMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("===== SHOP : Sword List =====");
                        for (int i = 1; i <= 3; i++)
                        {
                            gameHandler.PrintItemFromShop(i);
                        }
                        Console.Write("Select Id: ");
                        id = Console.ReadLine();
                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        gameHandler.BuyItems(id, quantity);
                        break;
                    case "2":
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine($"===== SHOP : L{input}Sword List =====");
                        gameHandler.PrintItemFromShop(int.Parse(input));
                        Console.Write("Select Id: ");
                        id = Console.ReadLine();
                        gameHandler.BuildHigherItem(id);
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("===== My Items List =====");
                        for (int i = 1; i <= 3; i++)
                        {
                            gameHandler.PrintItemFromMyItems(i);
                        }
                        Console.WriteLine($"My money: {gameHandler.MyMoney}");
                        break;
                    case "Q":
                    case "q":
                        Console.WriteLine("Good Bye.");
                        gameHandler.SaveFile();
                        return;
                }
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("1. Buy Item");
            Console.WriteLine("2. Build L2 Item");
            Console.WriteLine("3. Build L3 Item");
            Console.WriteLine("4. Show My All Items");
            Console.WriteLine("Q. Quit");
            Console.WriteLine("=============================");
            Console.Write("Select: ");
        }
    }
}
