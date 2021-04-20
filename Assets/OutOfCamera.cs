using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCamera : MonoBehaviour
{
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height,
            Camera.main.transform.position.z));
    }
    // Update is called once per frame
    void Update()
    {
        float cameraX = Camera.main.transform.position.x;
        float sum = transform.position.x + screenBounds.x;
        if (1.5*sum < cameraX)
        {
            Destroy(this.gameObject);
            Debug.Log("Object Destroyed");
        }
    }
}
