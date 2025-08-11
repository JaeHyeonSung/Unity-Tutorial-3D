using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public void StartQuest(string questName)
    {
        Debug.Log($"{questName} 수락");
    }
    public void ClearQuest(string questName)
    {
        Debug.Log($"{questName} 완료");
    }
    public void HasQuest(string questName)
    {
        Debug.Log($"{questName} 유무");
    }
}
