using UnityEngine;

public class DestroyZone : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy")) {
            other.gameObject.SetActive(false);

            if (other.gameObject.name.Contains("Bullet"))
            {
                PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);
                //PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                //player.bulletObjectPool.Add(other.gameObject);
                
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();

                //manager.enemyObjectPool.Add(other.gameObject);
                manager.enemyObjectPool.Enqueue(other.gameObject);
            }
        }
    }
}
