using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Single_BoardController : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform cellGroup;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Button restartButton;

    private Single_BoardTicTacToe gameBoard;
    private Single_Cell[,] cells = new Single_Cell[3, 3];

    private void Awake()
    {
        restartButton.onClick.AddListener(StartGame);
    }

    private void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        gameBoard = new Single_BoardTicTacToe();

        statusText.text = "Player O Turn";
        restartButton.gameObject.SetActive(false);
        for(int i=0; i<cellGroup.childCount; i++)
        {
            Destroy(cellGroup.GetChild(i).gameObject);
        }

        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject cellObj = Instantiate(cellPrefab, cellGroup);
                Single_Cell cell = cellObj.GetComponent<Single_Cell>();
                cell.SetButton(i, j, OnCellClicked);
                cells[i, j] = cell;
            }
        }
    }

    void OnCellClicked(int x, int y)
    {
        if(gameBoard.board[x, y] != 0)
        {
            return; // Cell already occupied
        }

        Single_Move move = new Single_Move(x,y,gameBoard.player);
        gameBoard.MakeMove(move);
        UpdateBoardVisual();
        CheckForGameOver();

    }
    void UpdateBoardVisual()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (gameBoard.board[i, j] == 1)
                {
                    cells[i, j].SetText("O");
                }
                else if (gameBoard.board[i, j] == 2)
                {
                    cells[i, j].SetText("X");
                }
                else
                {
                    cells[i, j].SetText("");
                }
            }
        }
    }

    void CheckForGameOver()
    {
        int winner = gameBoard.CheckWinner();
        if (winner ==0)
        {
            string nextPlayer = gameBoard.player == 1 ? "O" : "X";
            statusText.text = $"Player {nextPlayer} Turn";
            return;
        }
        if ((winner==3))
        {
            statusText.text = "Draw";
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            string result = winner == 1 ? "O" : "X";
            statusText.text = $"Player {result} Wins!";
            restartButton.gameObject.SetActive(true);
        }

    }
}
