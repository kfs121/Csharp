using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omok
{
    public enum CheckWins
    {
        xTDiag = +1,
        yTDiag = +1,

        xHoriz = 1,
        yHoriz = 0,

        xDDiag = 1,
        yDDiag = -1,

        xPerp = 0,
        yPerp = 1,
    };

    public enum WinWays
    {
        TDiag,
        Horiz,
        DDiag,
        Perp,
        Max
    };

    public enum Stones {
        Black = '○',
        White = '●'
    };

    class Program
    {
        const int board_max = 19;
        static void Main(string[] args)
        {
            Boolean keepGame = true;

            while (keepGame)
            {
                Boolean turn = true; //true is black
                Boolean gaming = true;

                char[,] board = GetBoard();

                List<string> places = GetPlaces();

                PrintOmok(board,null);

                while (gaming)
                {
                    gaming = PlayTurn(board, ref turn, places);
                    if (gaming == false)
                    {
                        keepGame = AskClose();
                    }
                }
            }

            Console.WriteLine("\nGame Close.");
            Console.ReadKey();
        }

        static char[,] GetBoard()
        {
            char[,] board = new char[board_max, board_max];

            board[0, 0] = '┌';
            for (int i = 1; i < board_max; i++)
            {
                board[0,i] = '┬';
            }
            board [0,board_max - 1] = '┐';

            for (int i = 1; i < board_max; i++)
            {
                board[i,0] = '├';
                for (int j = 1; j < board_max; j++)
                {
                    board[i,j] = '┼';
                }
                board[i,board_max-1] = '┤';
            }

            board[board_max-1,0] = '└';
            for (int i = 1; i < board_max; i++)
            {
                board[board_max-1, i] = '┴';
            }
            board[board_max-1, board_max-1] = '┘';

            return board;
        }

        static void PrintOmok(char[,] board, string botXY)
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
                    Console.Write(board[i,j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            if (botXY != null)
            {
                Console.WriteLine(botXY);
            }
        }

        static Boolean PlayTurn(char[,] board, ref Boolean turn, List<string> places)
        {
            char stone = GetStone(turn);
            string[] direc;
            int x, y;

            string botXY = null;

            while (true)
            {
                Console.Write($"{stone}'s X,Y: ");

                if (turn == true)
                {
                    direc = Console.ReadLine().Split(',');

                    x = int.Parse(direc[0]) - 1;
                    y = int.Parse(direc[1]) - 1;
                }
                else
                {
                    Random ran = new Random();

                    int direcL = ran.Next(places.Count);

                    direc = places[direcL].Split(' ');
                    x = int.Parse(direc[0]);
                    y = int.Parse(direc[1]);

                    botXY = $"{stone}'s X,Y: {x+1} {y+1}";
                }

                if (CheckBoard(board, x, y))
                {
                    board[y, x] = stone;
                    places.Remove($"{y} {x}");
                    break;
                }
                else
                {
                    if (turn == true)
                    {
                        Console.WriteLine("Can not put there. Try again.");
                    }
                }
            }

            turn = !turn;
            PrintOmok(board, botXY);
            return CheckWin(board, stone, x, y);
        }

        static Boolean CheckBoard(char[,] board, int x, int y) {

            if ((x >= 0 && y >= 0) && (x < board_max && y < board_max))
            {
                if ((board[y, x] == '○') || (board[y, x] == '●'))
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

        static char GetStone(Boolean turn) {
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

        static Boolean CheckWin(char[,] board, char stone, int x, int y)
        {
            Boolean winTDiag, winDDiag, winPerp, winHoriz;

            winTDiag = CheckBoardWin(board, stone, x, y, WinWays.TDiag);     //x + 1, y + 1 check
            winHoriz = CheckBoardWin(board, stone, x, y, WinWays.Horiz);
            winDDiag = CheckBoardWin(board, stone, x, y, WinWays.DDiag);
            winPerp = CheckBoardWin(board, stone, x, y, WinWays.Perp);
            
            if (winTDiag | winDDiag | winPerp | winHoriz)
            {
                Console.WriteLine($"{stone} Win.");
                return false;
            }

            return true;
        }

        static Boolean CheckBoardWin(char[,] board, char stone, int x, int y, WinWays way)    //인자를 적게쓰고 싶은데..
        {
            int winNum = 0;
            int checkX;
            int checkY;



            switch (way)
            {
                case WinWays.TDiag:
                    checkX = (int)CheckWins.xTDiag;
                    checkY = (int)CheckWins.xTDiag;
                    while ((x - 1) >= 0 && (y - 1) >= 0)
                    {
                        x = x - checkX;
                        y = y - checkY;
                    }
                    break;

                case WinWays.Horiz:
                    checkX = (int)CheckWins.xHoriz;
                    checkY = (int)CheckWins.yHoriz;

                    x = checkY;
                    break;

                case WinWays.DDiag:
                    checkX = (int)CheckWins.xDDiag;
                    checkY = (int)CheckWins.yDDiag;
                    while ((x - 1) >= 0 && (y - 1) >= 0)
                    {
                        x = x - checkX;
                        y = y - checkY;
                    }
                    break;

                case WinWays.Perp:
                    checkX = (int)CheckWins.xPerp;
                    checkY = (int)CheckWins.yPerp;
                    y = 0;
                    break;

                default:
                    checkX = 0;
                    checkY = 0;
                    break;

            }

            while ( (x >= 0 && y >= 0) && (x < 19 && y < 19) )
            {
                if (board[y, x] == stone)
                {
                    winNum++;
                }
                    y += checkY;
                    x += checkX;

                if (winNum >= 5)
                {
                    return true;
                }
            }

            return false;
        }

        static Boolean AskClose()
        {
            string answer;
            Boolean correct = true;
            
            
            while (correct)
            {
                Console.Write("Play Again? (y/n) : ");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "y":
                        return true;
                    case "n":
                        return false;

                    default:
                        Console.WriteLine("You entered it incorrectly.");
                        break;
                }
            }
            return true;
        }
    }
}
