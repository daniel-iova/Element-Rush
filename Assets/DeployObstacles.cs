using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployObstacles : MonoBehaviour
{
    public GameObject[]   obstaclePrefab;
    public float        respawnTime = 1.0f;
    public float        offsetSpawn = 100.0f;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(
           new Vector3(Screen.width, Screen.height,
           Camera.main.transform.position.z));
        
        spawnObstacle(true);

        StartCoroutine(obstaclePath());
        
    }
    public Vector2 CalculateBounds(GameObject a)
    {
        return a.GetComponent<BoxCollider2D>().size;
    }

    private void spawnObstacle(bool start = false)
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);

        GameObject a = Instantiate(obstaclePrefab[obstacleIndex]);

        Debug.Log(CalculateBounds(a));

        a.GetComponent<BoxCollider2D>().enabled = false;

        float cameraX = Camera.main.transform.position.x;

        if (start == true)
            a.transform.position = new Vector2(cameraX,
                                               transform.position.y);

        else
            a.transform.position = new Vector2(cameraX + offsetSpawn,
                                               transform.position.y);
                                               
        
    }
    IEnumerator obstaclePath()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
