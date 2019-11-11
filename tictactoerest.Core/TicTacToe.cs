using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoerest.Core
{
    public class TicTacToe
    {
        public static char[][] board;
        char[] Players = { 'x', 'o' };
        public string winner;
        public int count;
        public bool isOver;
        public int lastMoveBy;
        public TicTacToe()
        {
            board = new char[][]{
                                 new char[]{'.','.','.'},
                                 new char[] { '.','.','.'},
                                 new char[] {'.','.','.' }
                                 };
            isOver = false;
            count = 0;
            lastMoveBy = -1;
            winner = "none";
        }
        public char[][] GetState()
        {
            return board;
        }
        public string Move(int id, int row, int col)
        {
            int PlayerId = id;
            string message;
            if (isOver)
            {
                message = "Game is Over";
                //throw new Exception("Game is over");
            }
            else
            {
                if (PlayerId != 1 && PlayerId != 0)
                    return "Unknown Player";

                message = Place(PlayerId, row, col);
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
            
            if (row > 2 || col > 2 || row < 0 || col < 0)
                return "Illegal move Out of Board";

            if (PlayerId == lastMoveBy)
                return "It's not Your turn";

            if (board[row][col] != '.')
                return "Already filled this place";
                        
            lastMoveBy = PlayerId;
            board[row][col] = Players[PlayerId];
            return Players[PlayerId] + " has completed its turn";
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
                    if (board[i][j] == Players[playerId])
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
                    if (board[i][j] == Players[playerId])
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
                if (board[i][ i] == Players[playerId])
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
                if (board[i][ 3 - 1 - i] == Players[playerId])
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
