using Assets.Scripts.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleParentObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (ConfigFileUtil.GetValue("mode") == 2)
        {
            float randomPos = (Random.Range(0, 2) == 0) ? 5.5f : -5.5f;
            transform.position = new Vector2(transform.position.x, randomPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
