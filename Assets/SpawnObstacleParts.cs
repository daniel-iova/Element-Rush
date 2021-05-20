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

    // Start is called before the first frame update
    void Start()
    {
        SpawnParts();
        
    }
    private void SpawnParts()
    {
        int noParts = Random.Range(minimumNoParts, maximumNoParts);

        float xPos = this.transform.position.x;
        int   sign = -1;
        while (noParts != 0)
        {
            int selectPart = Random.Range(0, obstaclePartsPrefab.Length);

            GameObject part = Instantiate(obstaclePartsPrefab[selectPart]);
            

            part.transform.position = new Vector2(xPos, part.transform.position.y * sign);
            xPos += offsetX;
            sign *= -1;
            noParts--;

            part.transform.parent = thisGameObject.transform;

        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
