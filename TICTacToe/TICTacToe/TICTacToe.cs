using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TICTacToe
{
    class TICTacToe
    {
        public const int Size = 3;
        private int[,] board;
        public TICTacToe()//opens new board
        {
            board = new int[Size, Size];
            InitialiseBoard();
        }
        public void StartGame()
        {
            char player = '1';
            int x;
            int y;
            int movesCount = 0;
            while (movesCount < 5 || GameOn())
            {
                InOutPut.PrintBoard(board);
                InOutPut.Print("it's player " + player + "'s turn. enter the x and y you want to place ");
                x = InOutPut.InPut();
                y = InOutPut.InPut();
                while (x < 0 || x >= board.GetLength(0) || y < 0 || y > board.GetLength(1) || board[x, y] == 1 || board[x, y] == -1)
                {
                    InOutPut.Print("you've entered wrong coordinate. please enter coordinate within the board's border, and with nothing on them");
                    x = InOutPut.InPut();
                    y = InOutPut.InPut();
                }
                if (player == '1')
                    board[x, y] = 1;
                else
                {
                    board[x, y] = -1;
                }
                if (player == '1')
                    player = '2';
                else
                    player = '1';

                movesCount++;

            }
        }
        private void InitialiseBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }
        }

        public bool GameOn()
        {

            if (Win())
                return false;
            if (BoardIsFull())
            {
                InOutPut.PrintBoard(board);
                InOutPut.Print("draw!");
                return false;
            }
            return true;
        }
        public bool BoardIsFull()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool Win()// checks if someone won. if so, prints the winning player
        {
            int first = FirstSlantSum(), second = SecondSlantSum();
            int sumOfRaw, sumOfColumn;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sumOfRaw = SumRow(i);
                sumOfColumn = SumColumn(i);
                if (first == 3 || second == 3 || sumOfRaw == 3 || sumOfColumn == 3)
                {
                    InOutPut.PrintBoard(board);
                    InOutPut.Print("player 1 won!");
                    return true;
                }
                if (first == -3 || second == -3 || sumOfRaw == -3 || sumOfColumn == -3)
                {
                    InOutPut.PrintBoard(board);
                    InOutPut.Print("player 2 won!");
                    return true;
                }
            }
            return false;
        }

        private int SumRow(int row)// returns the row's sum
        {
            int sum = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sum += board[i, row];
            }
            return sum;
        }
        private int SumColumn(int column)// returns the column's sum
        {
            int sum = 0;
            for (int i = 0; i < board.GetLength(1); i++)
            {
                sum += board[column, i];
            }
            return sum;
        }

        private int FirstSlantSum()
        {
            int sum = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sum += board[i, i];
            }
            return sum;
        }
        private int SecondSlantSum()
        {
            int sum = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sum += board[board.GetLength(0) - 1 - i, i];
            }
            return sum;
        }
    }
}
