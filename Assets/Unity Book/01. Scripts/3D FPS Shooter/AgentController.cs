using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Camera camera;
    private NavMeshAgent agent;
    public NavMeshSurface surface;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        surface.transform.position = agent.transform.position;
        surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
        }

        if(Vector3.Distance(transform.position, surface.transform.position) > 4f)
        {
            surface.transform.position = agent.transform.position;
            surface.BuildNavMesh();
        }
    }
}
