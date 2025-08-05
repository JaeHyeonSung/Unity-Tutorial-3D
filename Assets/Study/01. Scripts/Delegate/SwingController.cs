using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    private Animator anim;

    private bool isSwing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSwing)
            {
                StartCoroutine(Co_Swing());
                
            }
        }
    }

    IEnumerator Co_Swing()
    {
        isSwing = true;
        anim.SetTrigger("Swing");
        SwingStart();
        float animLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animLength);
        SwingEnd();
        isSwing = false;
    }

    private void SwingStart()
    {
        Debug.Log("SwingStart");
    }
    private void SwingEnd()
    {
        Debug.Log("SwingEnd");
    }
}
