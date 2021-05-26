using Assets.Scripts.UtilityScripts;
using System.Linq;
using UnityEngine;

public class InvinciblePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (ConfigFileUtil.GetValue("mode") == 1) 
            {
                collision.GetComponent<Player>().SetInvincibleState(true);
            }
            else
            {
                MakeBothPlayersInvincible(collision);
            }
            Destroy(gameObject);
        }
    }

    private void MakeBothPlayersInvincible(Collider2D collision)
    {
        var rootGameObjects = collision.gameObject.scene.GetRootGameObjects();
        foreach (var p in rootGameObjects.Where(x => x.GetComponent<Player>() != null).Select(x => x.GetComponent<Player>()))
        {
            p.SetInvincibleState(true);
        }
    }
}
