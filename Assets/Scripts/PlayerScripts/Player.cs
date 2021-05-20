using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // Elements and their respective CircleCollider radius
    private readonly string[] elements = {"Air", "Earth", "Fire", "Water" };
    // Final sprites might have different sizes, so we set different values for the collider radius
    private readonly float[] elementColliderRadius = { .5f, .5f, .5f, .5f };

    public float jumpForce = 10f;

    public CircleCollider2D circleCollider;

    private SpriteRenderer spriteRenderer;
    private float width;
    private int currentElementIndex = -1;

    float time = 10;

    void ChangeSprite()
    {
        currentElementIndex = Random.Range(0, elements.Length);
        // Using placeholder sprites for now
        spriteRenderer.sprite = Resources.Load<Sprite>(Path.Combine("Sprites", "PlaceholderPlayer", $"player{elements[currentElementIndex]}"));
        // Change collider radius based on element
        circleCollider.radius = elementColliderRadius[currentElementIndex];
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        width = Camera.main.GetComponent<CameraUtils>().GetCameraWidth();
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

        if (time >= 5)
        {
            ChangeSprite();
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
        float cameraX = Camera.main.transform.position.x;
        if (transform.position.x + (circleCollider.radius) < (cameraX - (width / 2)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == elements[currentElementIndex])
        {
            // score increase etc

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
