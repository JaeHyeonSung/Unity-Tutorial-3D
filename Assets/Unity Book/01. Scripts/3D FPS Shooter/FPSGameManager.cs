using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FPSGameManager : MonoBehaviour
{
    public static FPSGameManager gm;

    public enum GameState
    {
        Ready,
        Run,
        GameOver
    }
    public GameState gState;
    public GameObject gameLabel;
    FPSPlayerMove fpsPlayer;
    Text gameText;
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    private void Start()
    {
        gState = GameState.Ready;
        fpsPlayer = GameObject.Find("Player").GetComponent<FPSPlayerMove>();
        gameText = gameLabel.GetComponent<Text>();
        gameText.text = "Ready...";

        gameText.color = new Color(255, 185, 0, 255);

        StartCoroutine(ReadyToStart());
    }

    private void Update()
    {
        if (fpsPlayer.hp <= 0)
        {
            fpsPlayer.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = Color.red;

            gState = GameState.GameOver;
        }
    }
    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gameText.text = "Go !";
        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run;
    }

}
