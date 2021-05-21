using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 35f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        Debug.Log(collision.name);
        
        // Need to create relationships between elements
        // When they collide the bullet must be affected by said relationships
        //Destroy(gameObject);
    }
}
