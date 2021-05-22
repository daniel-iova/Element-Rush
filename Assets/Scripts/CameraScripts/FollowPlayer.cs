using Assets.Scripts.UtilityScripts;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform[] player;

    void Update()
    {
        int noPlayers = player.Length;

        while(noPlayers--!= 0)
        {
            if (player[noPlayers].position.x > transform.position.x)
            {
                transform.position = new Vector3(player[noPlayers].position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
