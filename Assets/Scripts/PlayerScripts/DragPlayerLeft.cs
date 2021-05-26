using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPlayerLeft : MonoBehaviour
{

    public float dragForce = 1f;
    public Rigidbody2D rb;

    void Update()
    {
        rb.AddForce(Vector2.left * dragForce);
    }
}
