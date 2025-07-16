using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;

    public GameObject firePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
