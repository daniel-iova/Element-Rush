using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public float RangeStartSize = 1.7f;
    public float RangeEndSize = 2.3f;

    void Start()
    {
        float randomSize = Random.Range(RangeStartSize, RangeEndSize);
        gameObject.transform.localScale = new Vector3(randomSize, randomSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
