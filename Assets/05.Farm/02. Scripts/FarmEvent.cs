using Unity.Cinemachine;
using UnityEngine;

public class FarmEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            GameManager.Instance.SetCameraState(CameraState.Farm);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            GameManager.Instance.SetCameraState(CameraState.OutSide);
        }
    }
}
