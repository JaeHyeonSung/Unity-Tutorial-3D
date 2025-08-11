using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    public void PlaySound()
    {
        Debug.Log("Play Sound");
    }

    public void StopSound()
    {
        Debug.Log("Stop Sound");
    }
}