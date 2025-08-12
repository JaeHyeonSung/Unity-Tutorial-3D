using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public enum FarmState
    {
        Seed, Harvest
    }
    FarmState farmState;
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private Vector2 fieldSize = new Vector2(9, 6);

    [SerializeField] private float tileSize = 2f;

    [SerializeField] private LayerMask farmLayerMask;


    public GameObject plantPrefab;
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
        if (GameManager.Instance.cameraState == CameraState.Farm)
        {
            switch (farmState)
            {
                case FarmState.Seed:
                    OnSeed();
                    break;
                case FarmState.Harvest:
                    Harvest();
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
                    GameObject plant = Instantiate(plantPrefab, transform.GetChild(1));
                    plant.transform.position = hit.transform.position;
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

    void Harvest()
    {

    }
}
