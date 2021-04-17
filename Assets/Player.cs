using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Elements and their respective CircleCollider radius
    private readonly string[] elements = {"Air", "Earth" };
    private readonly float[] elementColliderRadius = { 5f, 5.8f };

    public float jumpForce = 10f;

    public CircleCollider2D circleCollider;

    private SpriteRenderer spriteRenderer;

    private int currentElementIndex = -1;

    void ChangeSprite()
    {
        currentElementIndex = Random.Range(0, elements.Length);
        spriteRenderer.sprite = Resources.Load<Sprite>($"Sprites/player{elements[currentElementIndex]}");
        // Change collider radius based on element
        circleCollider.radius = elementColliderRadius[currentElementIndex];
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        ChangeSprite();
    }

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.right * jumpForce;
        }
    }
}
