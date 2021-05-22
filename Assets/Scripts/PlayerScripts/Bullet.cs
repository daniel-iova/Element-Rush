using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 35f;
    public static float relationSpeed = 45f;
    private float damage = 20;

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

    private static void DestroyEachother(Bullet b)
    {
        Destroy(b.gameObject);
    }

    private static Dictionary<string, Action<Bullet>> GetRelationsForType(string type)
    {
        // fire and water cancel eachother out
        // air  and earth cancel eachother out
        float scaleMult = .8f;
        var dict = new Dictionary<string, Action<Bullet>>();
        dict.Add(type, (b) => { return; });
        switch (type)
        {
            case "Fire":
                dict.Add("Water", (b) => Destroy(b.gameObject));
                dict.Add("Air", (b) => FireAir(b));
                dict.Add("Earth", (b) => FireEarth(b, scaleMult));
                break;
            case "Water":
                dict.Add("Fire", (b) => Destroy(b.gameObject));
                dict.Add("Air", (b) => WaterAir(b, scaleMult));
                dict.Add("Earth", (b) => WaterEarth(b, scaleMult));
                break;
            case "Air":
                dict.Add("Earth", (b) => Destroy(b.gameObject));
                dict.Add("Fire", (b) => FireAir(b));
                dict.Add("Water", (b) => WaterAir(b, scaleMult));
                break;
            case "Earth":
                dict.Add("Air", (b) => Destroy(b.gameObject));
                dict.Add("Fire", (b) => FireEarth(b, scaleMult));
                dict.Add("Water", (b) => WaterEarth(b, scaleMult));
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

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(tag))
        {
            ApplyRelation(tag, collision.tag);
        }
    }

    private void ApplyRelation(string bulletType, string collisionType)
    {
        relationDictionary[bulletType][collisionType](this);
    }
}
