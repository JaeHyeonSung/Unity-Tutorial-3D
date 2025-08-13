using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Crop crop;
    [SerializeField] private Image slotImage;
    [SerializeField] private Button slotButton;
    public bool isEmpty = true;

    private void Awake()
    {
        slotButton.onClick.AddListener(UseCrop);
    }

    private void OnEnable()
    {
        slotButton.interactable= !isEmpty;
        slotImage.gameObject.SetActive(!isEmpty);
    }
    public void GetCrop(Crop crop)
    {
        isEmpty = false;

        this.crop = crop;
        slotImage.sprite = crop.icon;

        
    }
    private void UseCrop()
    {
        if(crop != null)
        {
            crop.Use();
            isEmpty = true;
            slotImage.gameObject.SetActive(false);
            slotButton.interactable = false;
            GameManager.Instance.itemManager.ItemUse();
        }
    }
}
