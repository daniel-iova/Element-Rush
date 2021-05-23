using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Player player;

    private static Dictionary<string, Vector3> colliderSize = new Dictionary<string, Vector3>()
    {
        { "Air", new Vector3(29.29f, 11.6f) },
        { "Fire", new Vector3(36.07f, 12.16f) },
        { "Water", new Vector3(24f, 11.6f) },
        { "Earth", new Vector3(30.84f, 11.6f) }
    };


    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.GetKeyCode("shoot")))
        {
            Shoot();
        }
    }

    private float scaleMultiplier = 0.07f; 

    private void Shoot()
    {
        string bulletType = player.GetCurrentElement();
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Path.Combine("Sprites", "Bullets", $"{bulletType}Bullet"));
        bullet.tag = bulletType;
        bullet.transform.localScale = new Vector3(bullet.transform.localScale.x * scaleMultiplier, bullet.transform.localScale.y * scaleMultiplier, bullet.transform.localScale.z);
        bullet.GetComponent<BoxCollider2D>().size = GetBulletColliderForType(bulletType);
    }

    private static Vector3 GetBulletColliderForType(string bulletType)
    {
        return colliderSize[bulletType];
    }
}
