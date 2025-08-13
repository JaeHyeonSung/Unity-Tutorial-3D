using System.Collections;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public enum FarmState
    {
        None, Seed, Harvest
    }
    FarmState farmState;
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private Vector2 fieldSize = new Vector2(9, 6);

    [SerializeField] private float tileSize = 2f;

    [SerializeField] private LayerMask farmLayerMask;

    [SerializeField] private GameObject[] crops; // 0: Wheat, 1: Potato, 2: Carrot, etc.

    public GameObject currentPlant;
    [SerializeField] private int currentPlantIndex;
    [SerializeField] private GameObject[] plants;

    private GameObject[,] tileArray;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;

        tileArray = new GameObject[(int)fieldSize.x, (int)fieldSize.y];

        CreateField();
    }
    private void Update()
    {
        if (farmState != FarmState.None)
        {
            switch (farmState)
            {
                case FarmState.Seed:
                    OnSeed();
                    break;
                case FarmState.Harvest:
                    OnHarvest();
                    break;
                default:
                    break;
            }
        }


    }
    void CreateField()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2;
        float offsetY = (fieldSize.y - 1) * tileSize / 2;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float posY = transform.position.z + j * tileSize - offsetY;

                GameObject tileObj = Instantiate(tilePrefab, transform.GetChild(0));
                tileObj.name = $"Tile{i}, {j}";
                tileObj.transform.position = new Vector3(posX, 0, posY);
                tileObj.GetComponent<Tile>().arrayPos = new Vector2Int(i, j);
            }
        }
    }

    void OnSeed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, farmLayerMask))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;
                if (tileArray[tileX, tileY] == null)
                {
                    //GameObject tile = hit.collider.gameObject;
                    GameObject plant = Instantiate(plants[currentPlantIndex], transform.GetChild(1));
                    plant.transform.position = hit.transform.position;
                    plant.GetComponent<Plant>().plantIndex = currentPlantIndex;
                    //GameObject plant = Instantiate(plantPrefab, tile.transform.position + Vector3.up * 0.1f, Quaternion.identity);
                    tileArray[tileX, tileY] = plant;
                }
                else
                {
                    Debug.Log("이 공간에는 이미 작물이 심어져 있습니다.");
                }
                
            }
        }
    }

    void OnHarvest()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, farmLayerMask))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;
                if (tileArray[tileX, tileY] != null)
                {
                    Plant plant = tileArray[tileX, tileY].GetComponent<Plant>();

                    if (plant.isHarvestable)
                    {
                        plant.gameObject.SetActive(false);
                        tileArray[tileX, tileY] = null;

                        StartCoroutine(HarvestRoutine(plant.plantIndex, hit.transform.position));
                    }
                    
                }
                
            }
        }
    }

    IEnumerator HarvestRoutine(int index, Vector3 pos)
    {
        int ranAmount = Random.Range(1, 4);

        for (int i=0; i < ranAmount; i++)
        {
            GameObject crop = Instantiate(crops[index]);
            crop.transform.position = pos + Vector3.up * 0.5f;
            
            yield return new WaitForSeconds(0.15f);
        }
       
    }

    public void SetState(FarmState newState)
    {
        if (farmState != newState)
        {
            farmState = newState;
        }
    }

    public void SetPlant(int index)
    {
        currentPlantIndex = index;
    }
}
