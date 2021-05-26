using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPartsMovement : MonoBehaviour
{
    
    public float        topLimitY;
    public float        bottomLimitY;
    public float        minSpeed;
    public float        maxSpeed;
    
    void Start()
    {
        AssignPartsSpeeds();
    }

    private void AssignPartsSpeeds()
    {
        int noChildren = this.transform.childCount;

        

        int position = 1;
        while(noChildren != 0)
        {
            noChildren--;
            
            float speed = Random.Range(minSpeed, maxSpeed);

            GameObject part = this.transform.GetChild(noChildren).gameObject;

            if (position == 1)
                part.transform.position = new Vector2(part.transform.position.x, topLimitY);
            else
                part.transform.position = new Vector2(part.transform.position.x, bottomLimitY);
            position *= -1;
            Rigidbody2D rb = part.GetComponent<Rigidbody2D>();
            
            if (topLimitY == part.transform.position.y)
            {
                rb.velocity = new Vector2(0, -speed);
            }
            else
                {
                    rb.velocity = new Vector2(0, speed);
                }
        }
    }

    private void UpdateParts()
    {
        int noChildren = this.transform.childCount;

        while (noChildren != 0)
        {
            noChildren--;

            GameObject part = this.transform.GetChild(noChildren).gameObject;

            Rigidbody2D rb = part.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector2(0, rb.velocity.y);

            if (rb.transform.position.y > topLimitY && rb.velocity.y > 0)
                rb.velocity = new Vector2(0, -rb.velocity.y);
            if (rb.transform.position.y < bottomLimitY && rb.velocity.y < 0)
                rb.velocity = new Vector2(0, -rb.velocity.y);

        }
    }

    void Update()
    {
        UpdateParts();   
    }
}
