using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnY : MonoBehaviour
{
    private float posY;

    // Start is called before the first frame update
    void Start()
    {
        posY = Random.Range(0, 2) == 0 ? Random.Range(5, 11) : Random.Range(-5, -11);
        if (posY < 0)
        {
            var rotator = GetComponent<Rotator>();
            if (rotator != null)
            {
                rotator.SetRotationDirection(-1);
            }
        }
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
