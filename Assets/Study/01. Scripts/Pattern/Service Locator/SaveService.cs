using UnityEngine;

public class SaveService : MonoBehaviour, ISaveService
{
    public void LoadData()
    {
        Debug.Log("Load Data");
    }

    public void SaveData()
    {
        Debug.Log("Save Data");
    }
}
