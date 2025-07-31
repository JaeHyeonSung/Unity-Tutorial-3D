using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FPSGameManager : MonoBehaviour
{
    public static FPSGameManager gm;

    public enum GameState
    {
        Ready,
        Run,
        Pause,
        GameOver
    }
    public GameState gState;
    public GameObject gameLabel;
    FPSPlayerMove fpsPlayer;
    Text gameText;
    public GameObject gameOption;
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        
        
        if (fpsPlayer.hp <= 0)
        {
            fpsPlayer.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = Color.red;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Transform buttons = gameText.transform.GetChild(0);

            buttons.gameObject.SetActive(true);

            gState = GameState.GameOver;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenOptionWindow();
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

    public void OpenOptionWindow()
    {
        gameOption.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        gState = GameState.Pause;
    }

    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
        gState = GameState.Run;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        //Application.Quit();
    }

}
