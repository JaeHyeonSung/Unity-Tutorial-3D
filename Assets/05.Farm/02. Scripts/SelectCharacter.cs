using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines.Interpolators;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform centerPivot;
    [SerializeField] private Button[] turnButtons;
    [SerializeField] private Button selectButton;
    [SerializeField] private Animator[] characterAnims;
    private bool isTurn;
    private int currIndex;
    private void Start()
    {
        currIndex = 0;
        turnButtons[0].onClick.AddListener(() => Turn(true));
        turnButtons[1].onClick.AddListener(() => Turn(false));

        selectButton.onClick.AddListener(() => Select());
    }

    void Turn(bool isLeft)
    {
        int idxValue = isLeft ? -1 : 1;
        float turnValue = idxValue * 90;
        var targetRot = centerPivot.transform.rotation * Quaternion.Euler(0, turnValue, 0);

        if (!isTurn)
        {
            currIndex += idxValue;
            if(currIndex> 3)
            {
                currIndex = 0;
            }
            else if (currIndex < 0)
            {
                currIndex = 3;
            }
            Debug.Log(currIndex);
            isTurn = true;
            StartCoroutine(TurnRoutine(targetRot));
        }
        
    }

    IEnumerator TurnRoutine(Quaternion targetRot)
    {
        while (true)
        {
            yield return null;
            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, 7f * Time.deltaTime);

            var angle = Quaternion.Angle(centerPivot.rotation, targetRot);
            if(angle<=0.1f)
            {
                isTurn = false;
                centerPivot.rotation = targetRot;
                yield break;
            }
        }
    }
    void Select()
    {
        Debug.Log($"현재 선택된 캐릭터는 {currIndex} 번쨰 입니다");
        StartCoroutine(SelectRoutine());

    }

    IEnumerator SelectRoutine()
    {
        characterAnims[currIndex].SetTrigger("Select");
        yield return new WaitForSeconds(3f);

        Fade.onFadeAction?.Invoke(5f, Color.white, true, new System.Action(()=> SceneManager.LoadScene(2)));
        yield return new WaitForSeconds(3.5f);

        
    }
}
