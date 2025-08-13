using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private string cropName;
    public Sprite icon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GameManager.Instance.itemManager.GetItem(gameObject);
            Get();
        }
    }

    public void Get()
    {
        if(GameManager.Instance.itemManager.CheckItemCount())
        {
            GameManager.Instance.itemManager.GetItem(this);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("인벤토리가 가득 찼습니다. 아이템을 획득할 수 없습니다.");
        }
        
    }

    public void Use()
    {

    }
}
