using System;
using System.Collections.Generic;
using System.Text;

namespace Gacha2
{
    enum EType
    {
        Sword, Shield, Hat, Boots
    }
    class Item
    {
        public string Id { get; private set; }
        public EType Type { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }
        public int Piece { get; private set; }
        public float Ratio { get; private set; }
        public int Price { get; private set; }
        public Item(string id, EType type, string name, int level, int power, int piece, float ratio, int price)
        {
            Id = id;
            Type = type;
            Name = name;
            Level = level;
            Power = power;
            Piece = piece;
            Ratio = ratio;
            Price = price;
        }
        public Item(Item item)
        {
            Id = item.Id;
            Type = item.Type;
            Name = item.Name;
            Level = item.Level;
            Power = item.Power;
            Piece = item.Piece;
            Ratio = item.Ratio;
            Price = item.Price;
        }
        public void PrintItem()
        {
            Console.WriteLine($"Id: {Id}, Type: {Type}, Name: {Name}, Level: {Level}, Power: {Power}, Piece: {Piece}, Ratio: {Ratio}, Price: {Price}");
        }
    }
}
