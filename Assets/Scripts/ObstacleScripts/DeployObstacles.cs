using System.Collections;
using System.Linq;
using UnityEngine;

public class DeployObstacles : MonoBehaviour
{
    public GameObject[]   obstaclePrefab;
    public float  respawnTime = 1.0f;
    public float  offsetSpawn = 10f;
    public float spacing = 15f;
    public int maxObstacleCount = 10;
    private float width;
    private int obstacleCount = 0;

    void Start()
    {
        
        SpawnObstacle(true);
        obstacleCount++;
        StartCoroutine(ObstaclePath());
        width = Camera.main.GetComponent<CameraUtils>().GetCameraWidth();
        
    }

    private void SpawnObstacle(bool start = false)
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);

        GameObject a = Instantiate(obstaclePrefab[obstacleIndex]);

        a.GetComponent<BoxCollider2D>().enabled = false;

        float cameraX = Camera.main.transform.position.x;

        if (start == true)
            a.transform.position = new Vector2(cameraX,
                                               transform.position.y);

        else
            a.transform.position = new Vector2( cameraX + (width / 2) + offsetSpawn,
                                               transform.position.y);

        offsetSpawn += a.GetComponent<BoxCollider2D>().size.x + spacing;
    }
    IEnumerator ObstaclePath()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            if (obstacleCount < maxObstacleCount)
            {
                SpawnObstacle();
                obstacleCount++;
            }
        }
    }

    public void DecrementObstacleCount()
    {
        obstacleCount--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
