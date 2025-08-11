using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public void AddItem(string itemName)
    {
        Debug.Log($"{itemName} È¹µæ");
    }
    public void HasItem(string itemName)
    {
        Debug.Log($"{itemName} À¯¹«");
    }
    public void RemoveItem(string itemName)
    {
        Debug.Log($"{itemName} ¹ö¸²");
    }
}
