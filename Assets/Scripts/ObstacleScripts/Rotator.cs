using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float MaximumRotationSpeed = 200f;
    private float rotationSpeed;
    private int rotationDirection = 1;

    private void Start()
    {
        rotationSpeed = Random.Range(100, MaximumRotationSpeed);
    }
    void Update()
    {
        transform.Rotate(0f, 0f, rotationDirection * rotationSpeed * Time.deltaTime);
    }
    
    public void SetRotationDirection(int newDirection)
    {
        rotationDirection = newDirection;
    }
}
