using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    enum EWeapon
    {
        Bow = 1,
        Bullet = 2,
        Rocket = 3,
        Missile = 4
    };
    enum EDirection
    {
        Up = 8,
        Down = 2,
        Left = 4,
        Right = 6
    };
    class Program
    {
        static void Main(string[] args)
        {
            int eHP = 10;
            int pX = 10;
            int pY = 10;

            EWeapon playerWeapon;
            EDirection playerDirection;

            while (eHP > 0)
            {
                PrintState(eHP, pX, pY);
                playerWeapon = InputWeapon();
                Fire(playerWeapon, ref eHP);

                playerDirection = InputDirection();
                Move(playerDirection, ref pX, ref pY);
                Console.WriteLine();
            }

            Console.WriteLine("Enemy Killed.");

            Console.ReadKey();
        }

        static void Fire(EWeapon weapon, ref int eHP)
        {
            switch (weapon)
            {
                case EWeapon.Bow:
                    Console.WriteLine("!");
                    break;

                case EWeapon.Bullet:
                    Console.WriteLine("!!");
                    break;

                case EWeapon.Rocket:
                    Console.WriteLine("!^!");
                    break;

                case EWeapon.Missile:
                    Console.WriteLine("!^^!");
                    break;
            }

            eHP = eHP - (int)weapon;
        }

        static void PrintState(int eHP, int playerX, int playerY)
        {
            Console.WriteLine($"Enemy HP : {eHP}");
            Console.WriteLine($"Player Position : {playerX},{playerY}");
        }

        static EWeapon InputWeapon()
        {
            Console.Write("Enter weapon(1~4): ");
            return (EWeapon)int.Parse(Console.ReadLine());
        }

        static EDirection InputDirection()
        {
            Console.Write("Enter direction(U8,D2,L4,R6): ");
            return (EDirection)int.Parse(Console.ReadLine());
        }

        static void Move(EDirection direc, ref int pX, ref int pY)
        {
            switch (direc)
            {
                case EDirection.Up:
                    pY += 1;
                    break;

                case EDirection.Down:
                    pY -= 1;
                    break;

                case EDirection.Left:
                    pX -= 1;
                    break;

                case EDirection.Right:
                    pX += 1;
                    break;
            }
        }
    }
}