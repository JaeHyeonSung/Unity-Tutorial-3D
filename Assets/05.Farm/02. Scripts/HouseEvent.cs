using Unity.Cinemachine;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] private GameObject houseTop;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "Player")
        {
            GameManager.Instance.SetCameraState(CameraState.House);
            houseTop.SetActive(false);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            GameManager.Instance.SetCameraState(CameraState.OutSide);
            houseTop.SetActive(true);
        }
        
    }
}
