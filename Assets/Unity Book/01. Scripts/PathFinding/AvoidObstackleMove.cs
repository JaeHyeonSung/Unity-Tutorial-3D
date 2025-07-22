using UnityEngine;

public class AvoidObstackleMove : MonoBehaviour
{
    public float speed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f;

    private float curSpeed;
    private Vector3 targetPoint;
    public float steeringForce = 10f;

    private void Start()
    {
        targetPoint = Vector3.zero;

    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                targetPoint = hit.point;  // 목표지점
            }
        }

        Vector3 dir = targetPoint - transform.position;
        dir.Normalize();

        dir = GetAvoidanceDirection(dir);

        if(Vector3.Distance(targetPoint, transform.position) < 1f)
        {
            return;
        }
        curSpeed = speed * Time.deltaTime;
        Quaternion rot = Quaternion.LookRotation(dir);

        transform.position += transform.forward * curSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation,rot,steeringForce*Time.deltaTime);
    }


    public Vector3 GetAvoidanceDirection(Vector3 dir)
    {
        RaycastHit hit;
        int layerMask = 1 << 15;
        if(Physics.Raycast(transform.position, transform.forward, out hit, minDistToAvoid, layerMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0f;

            dir = transform.forward + hitNormal * force;
            dir.Normalize();
        }
        return dir;
    }




}
