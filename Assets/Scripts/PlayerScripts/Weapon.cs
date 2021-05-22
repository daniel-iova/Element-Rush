using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Player player;

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
    }
}
