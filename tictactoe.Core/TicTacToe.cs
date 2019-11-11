using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe.Core
{
    public class TicTacToe
    {
        public static char[,] board;
        char[] Players = { 'x', 'o' };
        public string winner;
        public int count;
        public bool isOver;
        public TicTacToe()
        {
            board = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '.';
                }
            }
            isOver = false;
            count = 0;
            winner = "none";
        }
        public char[,] GetState()
        {
            return board;
        }
        public string Start(Game g)
        {
            int PlayerId = g.id;
            string message;
            if (isOver)
            {
                message = "Game is Over";
                //throw new Exception("Game is over");
            }
            else
            {
                message = place(PlayerId, g.row, g.col);
                count++;
                if (WinnerCheck(PlayerId))
                {
                    winner = "Winner is" + Players[PlayerId];
                    message = winner;
                    isOver = true;
                }
                else if (count >= 9)
                {
                    winner = "Tie";
                    message = winner;
                    isOver = true;
                }
            }
            return message;
        }
        public string Place(int PlayerId, int row, int col)
        {
            if (board[row, col] != '.')
            {
                return "Already filled this place";
            }
            else if (row > 2 || col > 2 || row < 0 || col < 0)
            {
                return "Illegal move";
            }
            board[row, col] = Players[PlayerId];
            return PlayerId + "has completed its turn";
        }
        public bool WinnerCheck(int playerId)
        {
            if (CheckRows(playerId) || CheckCols(playerId) || CheckDiagnols(playerId))
            {
                return true;
            }
            return false;
        }
        public bool CheckRows(int playerId)
        {
            int flag = 0;
            for (int i = 0; i < 3; i++)
            {
                flag = 0;
                //val = arr[i, 0];
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == Players[playerId])
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                {
                    break;
                }
            }
            if (flag == 1)
            {
                return true;
            }
            return false;
        }
        public bool CheckCols(int playerId)
        {
            int flag = 0;
            for (int j = 0; j < 3; j++)
            {
                flag = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, j] == Players[playerId])
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                {
                    break;
                }
            }
            if (flag == 1)
            {
                return true;
            }
            return false;
        }
        public bool CheckDiagnols(int playerId)
        {
            int flag = 0;
            int i;
            for (i = 0; i < 3; i++)
            {
                if (board[i, i] == Players[playerId])
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    break;
                }
            }
            if (flag == 1)
            {
                return true;
            }

            flag = 0;
            for (i = 0; i < 3; i++)
            {
                if (board[i, 3 - 1 - i] == Players[playerId])
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    break;
                }
            }
            if (flag == 1)
            {
                return true;
            }
            return false;
        }

    }
}
