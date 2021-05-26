using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private readonly string[] elements = { "Air", "Earth", "Fire", "Water" };

    private static Dictionary<string, Vector3> colliderSize = new Dictionary<string, Vector3>()
    {
        { "Air", new Vector3(29.29f, 11.6f) },
        { "Fire", new Vector3(36.07f, 12.16f) },
        { "Water", new Vector3(24f, 11.6f) },
        { "Earth", new Vector3(30.84f, 11.6f) }
    };

    public float fireTime = 5;
    float time = 10;

    private void Start()
    {
        

    }

    void Update()
    {
        if (time > fireTime)
        {
            time = 0;

            Shoot();
        }
        else
            time += Time.deltaTime;
    }

    private float scaleMultiplier = 0.07f;

    private void Shoot()
    {
        int index = Random.Range(0, elements.Length);

        string bulletType = elements[index];

        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Path.Combine("Sprites", "Bullets", $"{bulletType}Bullet"));
        // Increase scale
        bullet.transform.localScale = new Vector2(2, 2);

        bullet.tag = bulletType;
        bullet.transform.localScale = new Vector3(bullet.transform.localScale.x * scaleMultiplier, bullet.transform.localScale.y * scaleMultiplier, bullet.transform.localScale.z);
        bullet.GetComponent<BoxCollider2D>().size = GetBulletColliderForType(bulletType);
    }

    private static Vector3 GetBulletColliderForType(string bulletType)
    {
        return colliderSize[bulletType];
    }
}
