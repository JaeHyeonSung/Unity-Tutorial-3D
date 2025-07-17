using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int poolSize = 10;

    //public GameObject[] enemyObjectPool;
    //public List<GameObject> enemyObjectPool;
    public Queue<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    float currentTime;
    public float createTime=1;
    private float minTime = 1;
    private float maxTime = 5;


    public GameObject enemyFactory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        createTime = Random.Range(minTime, maxTime);
        //enemyObjectPool = new GameObject[poolSize];
        //enemyObjectPool = new List<GameObject>();
        enemyObjectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            //enemyObjectPool.Add(enemy);
            enemyObjectPool.Enqueue(enemy);
            enemy.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime>createTime)
        {
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);

            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool.Dequeue();
                

                int ranIndex = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[ranIndex].position;
                enemy.SetActive(true);

            }




            //리스트 방식 풀
            //if (enemyObjectPool.Count > 0)
            //{
            //    GameObject enemy = enemyObjectPool[0];
            //    enemyObjectPool.Remove(enemy);

            //    int ranIndex = Random.Range(0, spawnPoints.Length);
            //    enemy.transform.position = spawnPoints[ranIndex].position;
            //    enemy.SetActive(true);

            //}

            //for(int i=0; i<poolSize; i++)
            //{
            //    GameObject enemy = enemyObjectPool[i];
            //    if(!enemy.activeSelf)
            //    {
            //        enemy.SetActive(true);
            //        int ranIndex = Random.Range(0, spawnPoints.Length);
            //        enemy.transform.position = spawnPoints[ranIndex].position;
            //        break;

            //    }
            //}
        }
    }
}
