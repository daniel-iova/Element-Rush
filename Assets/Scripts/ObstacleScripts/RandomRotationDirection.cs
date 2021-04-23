using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotationDirection : MonoBehaviour
{
    // Only use this with obstacles that have a Rotator and are not direction dependent to function

    private Rotator rotator;

    void Start()
    {
        rotator = GetComponent<Rotator>();
        rotator.SetRotationDirection(Random.Range(0, 2) == 0 ? 1 : -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
