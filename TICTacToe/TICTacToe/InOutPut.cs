using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TICTacToe
{
    class InOutPut
    {
       public static void Print(String str)
        {
            Console.WriteLine(str);
        }
        public static void PrintOneLine(String str)
        {
            Console.Write(str);
        }
        public static int InPut()
        {
            return int.Parse(Console.ReadLine());
        }
        public static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        InOutPut.PrintOneLine(" - ");
                    }
                    else if (board[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        InOutPut.PrintOneLine(" x ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        InOutPut.PrintOneLine(" o ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                InOutPut.Print("");
            }
        }

    }
}
