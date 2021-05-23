using UnityEngine;

public class PlaceOnY : MonoBehaviour
{
    private float posY;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle obstacle = GetComponent<Obstacle>();
        (float posStart, float posEnd) = obstacle.GetPositionRangeBasedOnPlayMode();
        posY = Random.Range(0, 2) == 0 ? 
            Random.Range(posStart, posEnd) :
            Random.Range(-posEnd, -posStart);
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
}
