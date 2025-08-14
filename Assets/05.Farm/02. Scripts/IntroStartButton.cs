using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroStartButton : MonoBehaviour
{
    private void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }
    void OnButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
