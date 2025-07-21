using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public static ScoreManager instance = null;
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currentScore;
    private int bestScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int Score
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            currentScoreUI.text = "���� ���� : " + currentScore;

            if (currentScore > PlayerPrefs.GetInt("BestScore"))
            {
                bestScore = currentScore;
                bestScoreUI.text = "�ְ� ���� : " + bestScore;

                PlayerPrefs.SetInt("BestScore", bestScore);

            }
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }

    
}
