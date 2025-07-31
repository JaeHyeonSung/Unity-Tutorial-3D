using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    public int bombDamage = 10;
    public float explosionRadius = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, 1 << 9);

        for(int i=0; i<cols.Length; i++)
        {
            cols[i].GetComponent<EnemyFSM>().HitEnemy(bombDamage);
        }
        GameObject eff = Instantiate(bombEffect);
        eff.transform.position = transform.position;
        Destroy(gameObject);
    }
}
