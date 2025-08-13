using Unity.Cinemachine;
using UnityEngine;

public class FarmEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.Farm);
            GameManager.Instance.uiManager.ActivateFarmUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.OutSide);
            GameManager.Instance.uiManager.ActivateFarmUI(false);
        }
    }
}
