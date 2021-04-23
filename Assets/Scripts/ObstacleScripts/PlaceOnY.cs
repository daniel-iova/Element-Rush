using UnityEngine;

public class PlaceOnY : MonoBehaviour
{
    private float posY;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle obstacle = GetComponent<Obstacle>();
        posY = Random.Range(0, 2) == 0 ? 
            Random.Range(obstacle.RandomPostionRangeStart, obstacle.RandomPostionRangeEnd) : 
            Random.Range(-obstacle.RandomPostionRangeStart, -obstacle.RandomPostionRangeEnd);
        if (obstacle.RotationDependentOnPosition)
        {
            if (posY < 0)
            {
                var rotator = GetComponent<Rotator>();
                if (rotator != null)
                {
                    rotator.SetRotationDirection(-1);
                }
            }
        }
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
