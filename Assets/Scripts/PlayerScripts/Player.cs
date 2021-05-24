using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public GameManager gameManager;

    // Elements and their respective CircleCollider radius
    private readonly string[] elements = {"Air", "Earth", "Fire", "Water" };
    // Final sprites might have different sizes, so we set different values for the collider radius
    private readonly float[] elementColliderRadius = { 13.41f, 12.26f, 11.23f, 12.6f };

    // SET TO 1 FOR THE 2ND PLAYER IN THE 2P MODE
    public int Id = 0;

    public float jumpForce = 29f;

    public CircleCollider2D circleCollider;

    private SpriteRenderer spriteRenderer;
    private float width;
    private int currentElementIndex = -1;

    float time = 10;

    private int? shootKey, jumpKey;

    public KeyCode GetKeyCode(string actionType)
    {
        AssignKeys();
        switch (actionType)
        {
            case "shoot":
                return (KeyCode)shootKey;
            case "jump":
                return (KeyCode)jumpKey;
            default:
                return KeyCode.Return;
        }
    }

    private void AssignKeys()
    {
        dynamic json = Camera.main.GetComponent<CameraUtils>().GetKeysForPlayerId(Id);
        shootKey ??= (int)json.shoot;
        jumpKey ??= (int)json.jump;
    }

    void ChangeSprite()
    {
        currentElementIndex = Random.Range(0, elements.Length);
        // Using placeholder sprites for now
        spriteRenderer.sprite = Resources.Load<Sprite>(Path.Combine("Sprites", "Player", $"{elements[currentElementIndex]}Player"));
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

    private bool canChange = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GetKeyCode("jump")))
        {
            rb.velocity = Vector2.right * jumpForce;
        }

        if (time >= 5)
        {
            if (canChange == true)
            {
                ChangeSprite();
            }
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
        float cameraX = Camera.main.transform.position.x;
        if (transform.position.x + (circleCollider.radius*circleCollider.transform.localScale.x) < (cameraX - (width / 2)))
        {
            gameManager.GameOverSetup();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        canChange = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(elements[currentElementIndex]))
        {
            canChange = false;
        }
        else
        {
            // ADD TRY AGAIN AND QUIT BUTTONS + LOGIC
            gameManager.GameOverSetup();
        }
    }


    public string GetCurrentElement()
    {
        return elements[currentElementIndex];
    }
}
