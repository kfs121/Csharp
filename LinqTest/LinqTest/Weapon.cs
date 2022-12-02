using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest
{
    enum EType
    {
        Sword, Shield, Hat, Boots
    }
    class Weapon
    {
        public string Id { get; private set; }
        public EType Type { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }
        public int Piece { get; private set; }
        public float Ratio { get; private set; }

        public Weapon(string id, EType type, string name, int level, int power, int piece, float ratio)
        {
            Id = id;
            Type = type;
            Name = name;
            Level = level;
            Power = power;
            Piece = piece;
            Ratio = ratio;
        }
    }
}
