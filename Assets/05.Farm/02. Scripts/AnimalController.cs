using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    [SerializeField] private float wonderRadius = 15f;

    private float minWaitTime =1f;
    private float maxWaitTime =5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            Vector3 randomPos = Random.insideUnitSphere * wonderRadius;
            randomPos += transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPos, out hit, wonderRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
                anim.SetBool("isWalk", true);
            }
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            anim.SetBool("isWalk", false);
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimalEvent.failAction?.Invoke();
        }
    }
}

