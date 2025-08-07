using UnityEngine;

public class MoveFly : IMovement
{
    public float speed;
    public MoveFly(float speed)
    {
        this.speed = speed;
    }
    public void Move(Transform transform)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
