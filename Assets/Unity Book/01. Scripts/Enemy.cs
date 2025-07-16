using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;
    private void Start()
    {
        

        int randValue = Random.Range(0, 10);
        if (randValue < 3)
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
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        
        sm.SetScore(sm.GetScore() + 1);


        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}
