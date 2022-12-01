using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace gacha
{
    class GameHandler
    {
        public int MyMoney { get;private set;}
        List<Item> itemShop;
        List<Item> myItems;
        const string SHEET_PATH = @".\equipment.csv";
        const string ITEM_PATH = @".\items.txt";
        Random random;
        public GameHandler() 
        {
            itemShop = new List<Item>();
            myItems = new List<Item>();
            string[] lines = File.ReadAllLines(SHEET_PATH);
            for (int i = 1; i < lines.Length; i++)
            {
                char[] seperators = { ',' };
                string[] columns = lines[i].Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                itemShop.Add(new Item(columns[0], (EType)Enum.Parse(typeof(EType), columns[1]), columns[2], int.Parse(columns[3]), 
                    int.Parse(columns[4]), int.Parse(columns[5]), float.Parse(columns[6]), int.Parse(columns[7])));
            }
            random = new Random();
            if (!LoadFile())
            {
                MyMoney = 10000000;
            }
        }
        public void PrintItemFromShop(int level) 
        {
            List<Item> itemList = itemShop.Where(m => m.Level == level).ToList();
            foreach (Item item in itemList)
            {
                item.PrintItem();
            }
        }
        public void PrintItemFromMyItems(int level) 
        {
            List<Item> itemList = myItems.Where(m => m.Level == level).ToList();
            foreach (Item item in itemList)
            {
                item.PrintItem();
            }
        }
        public void BuyItems(string id, int quantity) 
        {
            Item item = itemShop.Where(m => m.Id == id).FirstOrDefault();
            if (item.Price * quantity > MyMoney)
            {
                Console.WriteLine("Not enough money.");
                return;
            }
            for (int i = 0; i < quantity; i++)
            {
                MyMoney -= item.Price;
                myItems.Add(new Item(item));
            }
            Console.WriteLine($"You have {MyMoney}won left.");
        }

        public void BuildHigherItem(string targetId) 
        {
            Item targetItem = itemShop.Where(m => m.Id == targetId).FirstOrDefault();
            while (true)
            {
                List<Item> myLowerItemList = myItems.Where(m => m.Level == targetItem.Level - 1).ToList();
                if (targetItem.Piece > myLowerItemList.Count)
                {
                    Console.WriteLine($"You have {myLowerItemList.Count} L{targetItem.Level-1} items.");
                    Console.WriteLine($"Not enough L{targetItem.Level-1} items.");
                    return;
                }
                int counter = 0;
                for (int i = myItems.Count - 1; i >= 0 && counter < targetItem.Piece; i--)
                {
                    if (myItems[i].Level == targetItem.Level - 1)
                    {
                        myItems.RemoveAt(i);
                        counter++;
                    }
                }
                Console.WriteLine($"You have {myLowerItemList.Count - targetItem.Piece} L{targetItem.Level - 1} items.");
                if (random.Next(10) / 10.0f > targetItem.Ratio) {
                    Console.Write("Build failed. Try again?(y/n) ");
                    string yn = Console.ReadLine();
                    if (yn == "Y" || yn == "y")
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                } else
                {
                    Console.WriteLine($"{targetItem.Name} added to your items.");
                    myItems.Add(targetItem);
                    break;
                }
            }
        }

        public void SaveFile() 
        {
            List<string> savedString = new List<string>();
            savedString.Add(MyMoney.ToString());
            foreach (Item item in myItems)
            {
                savedString.Add(item.Id);
            }
            File.WriteAllLines(ITEM_PATH, savedString);
        }
        public bool LoadFile() 
        {
            if (!File.Exists(ITEM_PATH))
            {
                return false;
            }
            string[] savedString = File.ReadAllLines(ITEM_PATH);
            MyMoney = int.Parse(savedString[0]);
            for (int i = 1; i < savedString.Length; i++)
            {
                Item item = itemShop.Where(m => m.Id == savedString[i]).FirstOrDefault();
                myItems.Add(item);
            }
            return true;
        }
    }
}