using Unity.Cinemachine;
using UnityEngine;

public enum CameraState
{
    OutSide, Farm, House, Animal
}

public class GameManager : Singleton<GameManager>
{
    public UIManager uiManager;
    public FarmManager farmManager;
    public ItemManager itemManager;
    public CameraState cameraState = CameraState.OutSide;
    [SerializeField] private CinemachineClearShot clearShot;



    public void SetCameraState(CameraState newState)
    {
        if (cameraState != newState)
        {
            cameraState = newState;

            foreach (var camera in clearShot.ChildCameras)
            {
                camera.Priority = 1;

            }
            clearShot.ChildCameras[(int)cameraState].Priority = 10;
        }
    }




}

