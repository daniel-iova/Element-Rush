using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBoxCollider : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public SpawnObstacleParts partsSpawner;

    public float spacing = 0.1f;

    void Start()
    {
        float partOffset = partsSpawner.offsetX;
        int obstacleNumber = partsSpawner.GetObstacleNumber();
        var child = partsSpawner.transform.GetChild(0).gameObject;
        var partWidth = child.GetComponent<BoxCollider2D>().size.y;

        boxCollider.size = new Vector2( (partOffset * (obstacleNumber - 1) + partWidth * 2) / 2+ spacing, boxCollider.size.y);
        boxCollider.offset = new Vector2( (boxCollider.size.x - partWidth )/ 2 - spacing/2, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
