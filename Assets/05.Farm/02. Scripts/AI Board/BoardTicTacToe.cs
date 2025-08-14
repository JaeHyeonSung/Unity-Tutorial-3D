using System.Collections.Generic;
using System;

public class BoardTicTacToe : Board
{
    private readonly int[,] board;
    private const int ROWS = 3;
    private const int COLS = 3;

    public BoardTicTacToe()
    {
        this.player = 1;
        board = new int[ROWS, COLS];
    }
    
    private BoardTicTacToe(int[,] board, int player)
    {
        this.board = board;
        this.player = player;
    }

    // 현재 게임판에서 둘 수 있는 모든 빈칸의 위치를 찾아 Move 배열로 반환합니다. AI가 다음 수를 생각할 때 사용합니다.
    public override Move[] GetMoves()
    {
        var moves = new List<Move>();
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (board[i, j] == 0)
                {
                    moves.Add(new MoveTicTac(j, i, player));
                }
            }
        }
        return moves.ToArray();
    }

    // 특정 위치에 말을 놓는 함수입니다. 현재 게임판을 그대로 바꾸지 않고, 새로운 말이 놓인 상태의 게임판을 복사하여 반환합니다.
    // AI가 여러 경우의 수를 시뮬레이션할 때 원본을 훼손하지 않게 해주는 중요한 부분입니다.
    public override Board MakeMove(Move m)
    {
        MoveTicTac move = m as MoveTicTac;
        int nextPlayer = (move.player == 1) ? 2 : 1;
        
        int[,] boardCopy = new int[ROWS, COLS];
        Array.Copy(board, boardCopy, board.Length);
        
        boardCopy[move.y, move.x] = move.player;
        
        return new BoardTicTacToe(boardCopy, nextPlayer);
    }
    
    public override bool IsGameOver()
    {
        return CheckWinner() != 0;
    }

    // 현재 게임판 상태에서 승리, 패배, 또는 무승부가 결정되었는지 확인합니다.
    // 가로, 세로, 대각선을 모두 검사하여 승자를 가려내고, 모든 칸이 찼지만 승자가 없으면 무승부(3)로 판단합니다.
    // 아직 게임이 진행 중이면 0을 반환합니다.
    public override int CheckWinner()
    { 
        // 가로/세로 확인
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) return board[i, 0];
            if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i]) return board[0, i];
        }
        // 대각선 확인
        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) return board[0, 0];
        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) return board[0, 2];
        
        // 무승부 확인
        bool isDraw = true;
        for (int i = 0; i < ROWS; i++) {
            for (int j = 0; j < COLS; j++) {
                if (board[i, j] == 0) {
                    isDraw = false;
                    break;
                }
            }
        }
        if (isDraw) return 3;
        
        return 0; // 게임 진행 중
    }
    
    public int GetCell(int row, int col)
    {
        return board[row, col];
    }
}