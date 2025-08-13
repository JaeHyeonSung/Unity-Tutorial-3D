using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject outSideUI;
    [SerializeField] private GameObject farmUI;
    [SerializeField] private GameObject houseUI;
    [SerializeField] private GameObject animalUI;
    [SerializeField] private GameObject seedUI;
    [SerializeField] private GameObject inventoryUI;

    [SerializeField] private Button seedButton;
    [SerializeField] private Button harvestButton;
    [SerializeField] private Button[] plantButtons;

    private void Awake()
    {
        seedButton.onClick.AddListener(OnSeedButtonClicked);
        harvestButton.onClick.AddListener(OnHarvestButtonClicked);


        for(int i =0; i<plantButtons.Length; i++)
        {
            int j = i;
            plantButtons[i].onClick.AddListener(()=>GameManager.Instance.farmManager.SetPlant(j));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    void OnSeedButtonClicked()
    {
        GameManager.Instance.farmManager.SetState(FarmManager.FarmState.Seed);
        //outSideUI.SetActive(false);
        //farmUI.SetActive(true);
        seedUI.SetActive(true);
    }

    void OnHarvestButtonClicked()
    {
        GameManager.Instance.farmManager.SetState(FarmManager.FarmState.Harvest);
        //outSideUI.SetActive(false);
        //farmUI.SetActive(true);
        seedUI.SetActive(false);
    }

    public void ActivateFarmUI(bool isActive)
    {
        farmUI.SetActive(isActive);
    }
}
