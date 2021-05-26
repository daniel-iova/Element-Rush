using UnityEngine;
using UnityEngine.Events;

public class DynamicBoxCollider : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public SpawnObstacleParts partsSpawner;

    public UnityEvent uEvent;

    public float spacing = 0.1f;

    private bool computed = false;

    void Start()
    {
        float partOffset = partsSpawner.offsetX;
        int obstacleNumber = partsSpawner.GetObstacleNumber();
        var partWidth = partsSpawner.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().size.y;

        boxCollider.size = new Vector2( (partOffset * (obstacleNumber - 1) + partWidth * 2) / 2+ spacing, boxCollider.size.y);
        boxCollider.offset = new Vector2( (boxCollider.size.x - partWidth )/ 2 - spacing/2, 0);
        computed = true;
    }

    public bool GetComputed()
    {
        return computed;
    }

    public float GetColliderXOffset()
    {
        return boxCollider.size.x + boxCollider.offset.x;
    }

    void Update()
    {
        
    }

    internal void SetComputed(bool v)
    {
        computed = v;
    }
}
