using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Single_BoardTicTacToe : MonoBehaviour
{
    public int[,] board;
    private const int ROWS = 3, COLS = 3;
    public int player;

    public Single_BoardTicTacToe()
    {
        board = new int[ROWS, COLS];
        player = 1;
    }

    public List<Single_Move> GetMoves()
    {
        var moves = new List<Single_Move>();
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (board[i, j] == 0)
                {
                    moves.Add(new Single_Move(i, j, player));
                }
            }
        }
        return moves;
    }

    public void MakeMove(Single_Move move)
    {
        if (board[move.x, move.y] != 0)
        {
            return;
        }
        board[move.x, move.y] = move.player;

        this.player = (move.player == 1) ? 2 : 1;
    }


    public int CheckWinner()
    {
        // Check rows
        for (int i = 0; i < ROWS; i++)
        {
            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }
        }
        // Check columns
        for (int j = 0; j < COLS; j++)
        {
            if (board[0, j] != 0 && board[0, j] == board[1, j] && board[1, j] == board[2, j])
            {
                return board[0, j];
            }
        }
        // Check diagonals
        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }
        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }
        // ¹«½ÂºÎ
        if (GetMoves().Count == 0)
            return 3;
        return 0; // No winner
    }
    public int IsGameOver()
    {
        int winner = CheckWinner();
        if (winner != 0)
        {
            return winner; // Return the winner
        }
        // Check for a draw
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (board[i, j] == 0)
                {
                    return -1; // Game is still ongoing
                }
            }
        }
        return 0; // Draw
    }
}
