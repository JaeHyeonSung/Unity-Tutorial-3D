using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    public float createTime=1;
    private float minTime = 1;
    private float maxTime = 5;


    public GameObject enemyFactory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyFactory = Resources.Load<GameObject>("Enemy");
        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime>createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
