using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public float RandomSizeRangeStart = 1.7f;
    public float RandomSizeRangeEnd = 2.3f;
    public bool RotationDependentOnPosition = false;
    public float RandomPostionRangeStart;
    public float RandomPostionRangeEnd;

    void Start()
    {
        float randomSize = Random.Range(RandomSizeRangeStart, RandomSizeRangeEnd);
        gameObject.transform.localScale = new Vector3(randomSize, randomSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
