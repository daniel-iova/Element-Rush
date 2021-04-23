using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player.position.x > transform.position.x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
