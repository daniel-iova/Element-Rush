using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleParts : MonoBehaviour
{
    public GameObject       thisGameObject;
    public GameObject[]     obstaclePartsPrefab;
    public float            offsetX = 4.0f;
    public int              minimumNoParts = 4;
    public int              maximumNoParts = 12;

    private int NoParts;

    void Start()
    {
        NoParts = Random.Range(minimumNoParts, maximumNoParts);
        SpawnParts();
    }
    private void SpawnParts()
    {
        float xPos = this.transform.position.x;
        int noParts = NoParts;
        int sign = -1;
        while (noParts != 0)
        {
            int selectPart = Random.Range(0, obstaclePartsPrefab.Length);

            GameObject part = Instantiate(obstaclePartsPrefab[selectPart]);
            

            part.transform.position = new Vector2(xPos, part.transform.position.y * sign);
            part.transform.localScale *= Random.Range(.9f, 1.1f);
            xPos += offsetX;
            sign *= -1;
            noParts--;

            part.transform.parent = thisGameObject.transform;
        }
    }

    public int GetObstacleNumber()
    {
        return NoParts;
    }
}
