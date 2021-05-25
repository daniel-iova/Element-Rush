using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D bc;
    private float speed = 50f;
    public static float relationSpeed = 45f;
    private float damage = 1f;

    private static readonly Dictionary<string, Dictionary<string, Action<Bullet>>> relationDictionary = GetRelations();

    private static Dictionary<string, Dictionary<string, Action<Bullet>>> GetRelations()
    {
        var relations = new Dictionary<string, Dictionary<string, Action<Bullet>>>();
        string[] types = new string[] { "Air", "Fire", "Water", "Earth" };
        foreach (string type in types)
        {
            relations.Add(type, GetRelationsForType(type));
        }
        return relations;
    }

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

    private static Dictionary<string, Action<Bullet>> GetRelationsForType(string type)
    {
        // fire and water cancel eachother out
        // air  and earth cancel eachother out
        float scaleMult = .8f;
        var dict = new Dictionary<string, Action<Bullet>>();
        switch (type)
        {
            case "Fire":
                dict.Add("Water", (b) => Destroy(b.gameObject));
                dict.Add("Air", (b) => Destroy(b.gameObject));
                dict.Add("Earth", (b) => Destroy(b.gameObject));
                break;
            case "Water":
                dict.Add("Fire", (b) => Destroy(b.gameObject));
                dict.Add("Air", (b) => Destroy(b.gameObject));
                dict.Add("Earth", (b) => Destroy(b.gameObject));
                break;
            case "Air":
                dict.Add("Earth", (b) => Destroy(b.gameObject));
                dict.Add("Fire", (b) => Destroy(b.gameObject));
                dict.Add("Water", (b) => Destroy(b.gameObject));
                break;
            case "Earth":
                dict.Add("Air", (b) => Destroy(b.gameObject));
                dict.Add("Fire", (b) => Destroy(b.gameObject));
                dict.Add("Water", (b) => Destroy(b.gameObject));
                break;
        }
        return dict;
    }

    private static void WaterEarth(Bullet b, float mult)
    {
        // descreases scale
        b.gameObject.transform.localScale = b.gameObject.transform.localScale * mult;
        if (b.gameObject.transform.localScale.x <= 0)
        {
            Destroy(b.gameObject);
        }
    }

    private static void WaterAir(Bullet b, float scaleMult)
    {
        // slows down
        b.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(b.gameObject.GetComponent<Rigidbody2D>().velocity.x - 2, 0);
        if (b.gameObject.GetComponent<Rigidbody2D>().velocity.x <= 5)
        {
            Destroy(b.gameObject);
        }
    }

    private static void FireEarth(Bullet b, float mult)
    {
        // descreases scale
        b.gameObject.transform.localScale = b.gameObject.transform.localScale * mult;
        if (b.gameObject.transform.localScale.x <= 0)
        {
            Destroy(b.gameObject);
        }
    }
    private static void FireAir(Bullet b)
    {
        // decreases damage
        b.SetDamage(b.GetDamage() - 5);
        if (b.GetDamage() <= 0)
        {
            Destroy(b.gameObject);
        }
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
        if (collision.tag != "Untagged")
        {
            if (tag != collision.tag)
            {
                Barrier barrier = collision.GetComponent<Barrier>();
                if(barrier != null)
                {
                    ApplyRelation(tag, barrier.tag);

                    barrier.TakeDamage(damage);
                    
                }
                else
                    ApplyRelation(tag, collision.tag);

            }
        }
    }

    private void ApplyRelation(string bulletType, string collisionType)
    {
        relationDictionary[bulletType][collisionType](this);
    }
}
