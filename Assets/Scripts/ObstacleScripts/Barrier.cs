using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float health = 5f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
