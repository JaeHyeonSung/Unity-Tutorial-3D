using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;

    public int poolSize = 10;

    //GameObject[] bulletObjectPool;

    public GameObject firePosition;

    //public List<GameObject> bulletObjectPool;
    public Queue<GameObject> bulletObjectPool;

    private void Start()
    {
        //bulletObjectPool = new GameObject[poolSize];
       // bulletObjectPool = new List<GameObject>();
       bulletObjectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            //bulletObjectPool[i] = bullet;
            bulletObjectPool.Enqueue(bullet);
            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDARDALONE || UNITY_EDITOR
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("���콺 Ŭ��");
            // ť
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
            
        }
        
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("�հ��� ��ġ");

            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
#endif
    }
}
