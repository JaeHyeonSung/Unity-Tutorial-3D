using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public void StartSound(string soundName)
    {
        Debug.Log($"{soundName} 재생");
    }
    public void PauseSound(string soundName)
    {
        Debug.Log($"{soundName} 정지");
    }
    public void StopSound(string soundName)
    {
        Debug.Log($"{soundName} 종료");
    }
}
