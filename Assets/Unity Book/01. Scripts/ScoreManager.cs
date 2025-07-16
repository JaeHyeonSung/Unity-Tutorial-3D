using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currentScore;
    private int bestScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }

    public void SetScore(int value)
    {
        currentScore = value;
        currentScoreUI.text = "현재 점수 : " + GetScore();

        if (currentScore > PlayerPrefs.GetInt("BestScore"))
        {
            bestScore = GetScore();
            bestScoreUI.text = "최고 점수 : " + bestScore;

            PlayerPrefs.SetInt("BestScore", bestScore);

        }
    }

    public int GetScore()
    {
        return currentScore;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
