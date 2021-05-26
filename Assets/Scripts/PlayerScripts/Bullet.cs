using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D bc;
    private float speed = 50f;
    public static float relationSpeed = 45f;
    private float damage = 1f;


    private float width;

    void Start()
    {
        width = Camera.main.GetComponent<CameraUtils>().GetCameraWidth();
        bc = GetComponent<BoxCollider2D>();
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        if (OutOfBounds())
        {
            Destroy(gameObject);
        }    
    }

    private bool OutOfBounds()
    {
        if (transform.position.y> 20)
            return true;
        float cameraX = Camera.main.transform.position.x;

        return (transform.position.x + (bc.size.x + bc.offset.x) * transform.localScale.x > (cameraX + (width / 2) + 10));
    }


    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public float GetDamage()
    {
        return this.damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            if (tag != collision.tag)
            {
                Barrier barrier = collision.GetComponent<Barrier>();
                if(barrier != null)
                {
                    barrier.TakeDamage(damage);   
                }
                Destroy(gameObject);
            }
        }
    }
}
