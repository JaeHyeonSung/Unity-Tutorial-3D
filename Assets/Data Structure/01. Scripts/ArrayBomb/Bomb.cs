using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bombRb;
    public float bombTime=4f;
    public float bombRange = 10f;
    public LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);

        BombForce();
    }

    private void BombForce()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
        }
        Destroy(gameObject);
    }
}
