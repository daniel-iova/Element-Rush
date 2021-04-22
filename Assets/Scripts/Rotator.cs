using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float MaximumRotationSpeed = 100f;
    private float rotationSpeed;

    // Update is called once per frame
    private void Start()
    {
        rotationSpeed = Random.Range(50, MaximumRotationSpeed);
    }
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
