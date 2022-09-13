using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omok
{
    public enum Stones
    {
        Black = '●',
        White = '○'
    };

    class Program
    {
        const int board_max = 19;
        static void Main(string[] args)
        {
            Boolean turn = true; //true is black
            Boolean keep = true;
            char[,] board = GetBoard();
            List<string> places = GetPlaces();


            while (keep)
            {
                PrintOmok(board);
                keep = PlayTurn(board, ref turn, places);
                Console.ReadKey();
            }

            Console.WriteLine("\nGame Over.");
            Console.ReadKey();
        }



        static char[,] GetBoard()
        {
            char[,] board = new char[board_max, board_max];

            board[0, 0] = '┌';
            for (int i = 1; i < board_max; i++)
            {
                board[0, i] = '┬';
            }
            board[0, board_max - 1] = '┐';

            for (int i = 1; i < board_max; i++)
            {
                board[i, 0] = '├';
                for (int j = 1; j < board_max; j++)
                {
                    board[i, j] = '┼';
                }
                board[i, board_max - 1] = '┤';
            }

            board[board_max - 1, 0] = '└';
            for (int i = 1; i < board_max; i++)
            {
                board[board_max - 1, i] = '┴';
            }
            board[board_max - 1, board_max - 1] = '┘';

            return board;
        }


        static void PrintOmok(char[,] board)
        {
            Console.Clear();
            Console.WriteLine("    ====== Let's Play Omok ======\n");

            Console.Write("  ");          //바둑판 시작
            for (int i = 1; i <= board_max; i++)
            {
                Console.Write("{0,2}", i);
            }
            Console.Write("\n");

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write("{0,2}", i + 1);

                for (int j = 0; j < board.GetLength(0); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }


        static Boolean PlayTurn(char[,] board, ref Boolean turn, List<string> places)
        {
            char stone = GetStone(turn);
            string[] direc;

            int x, y;

            while (true)
            {
                Console.Write($"{stone}'s X,Y: ");

                if (turn == true)
                {
                    direc = Console.ReadLine().Split(',');

                    y = int.Parse(direc[0]) - 1;
                    x = int.Parse(direc[1]) - 1;
                }
                else
                {
                    Random ran = new Random();

                    int direcL = ran.Next(places.Count);
                    Console.WriteLine($"places : {places[direcL]}");

                    direc = places[direcL].Split(' ');
                    y = int.Parse(direc[0]);
                    x = int.Parse(direc[1]);

                    Console.WriteLine($"x : {x}, y : {y}");
                }

                //

                if (CheckBoard(board, x, y))
                {
                    board[x, y] = stone;
                    places.Remove($"{y} {x}");
                    Console.WriteLine($"Removed {y} {x}");
                    break;
                }
                else
                {
                    if (turn == true)               // stone == (char)Stones.Black
                    {
                        Console.WriteLine("Can not put there. Try again.");
                    }
                }


            }


            turn = !turn;

            return true;
        }





        static Boolean CheckBoard(char[,] board, int x, int y)
        {

            if ((x >= 0 && y >= 0) && (x < board_max && y < board_max))
            {
                if ((board[x, y] == '○') || (board[x, y] == '●'))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }



        static char GetStone(Boolean turn)
        {
            if (turn)
            {
                return (char)Stones.Black;
            }
            else
            {
                return (char)Stones.White;
            }
        }


        static List<string> GetPlaces()
        {
            List<string> places = new List<string>();

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    places.Add($"{i} {j}");
                }
            }

            return places;
        }
    }
}
