using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;
    private void OnEnable()
    {
        transform.rotation = Quaternion.identity;
        int randValue = Random.Range(0, 10);
        if (randValue < 7)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }
    // Update is called once per frame
    void Update()
    {

        transform.position += dir * speed * Time.deltaTime; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManager.instance.Score++;
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;


        if (collision.gameObject.name.Contains("Bullet"))
        {
            PlayerFire.Instance.bulletObjectPool.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
            
        }
          
        



        gameObject.SetActive(false);

        // EnemyÇ®¿¡ Enemy »ðÀÔ
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        //manager.enemyObjectPool.Add(gameObject);
        manager.enemyObjectPool.Enqueue(gameObject);
    }
}
