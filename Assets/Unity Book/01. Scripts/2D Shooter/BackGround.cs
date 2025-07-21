using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material bgMaterial;

    public float scrollSpeed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.up;
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
