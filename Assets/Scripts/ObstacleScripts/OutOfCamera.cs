using UnityEngine;

public class OutOfCamera : MonoBehaviour
{
    private BoxCollider2D bc;
    private float width;


    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        width = Camera.main.GetComponent<CameraUtils>().GetCameraWidth();
    }
    // Update is called once per frame
    void Update()
    {
        float cameraX = Camera.main.transform.position.x;
        if (transform.position.x + (bc.size.x) < (cameraX - (width/2)))
        {
            GameObject.FindGameObjectsWithTag("ObstacleSpawner")[0].GetComponent<DeployObstacles>().DecrementObstacleCount();
            Destroy(this.gameObject);
        }
    }
}
