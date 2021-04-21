using UnityEngine;

public class OutOfCamera : MonoBehaviour
{
    private BoxCollider2D bc;
    private float width;


    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        float height = 2f * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }
    // Update is called once per frame
    void Update()
    {
        float cameraX = Camera.main.transform.position.x;
        if (transform.position.x + (bc.size.x) < (cameraX - width / 2))
        {
            Destroy(this.gameObject);
        }
    }
}
