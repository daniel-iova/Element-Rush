using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float moveDistance = 0.1f;

    public float moveCameraAfter = 2.0f;
    private float currentTime = 0;

    private float startDistance;
    private float currentDistance;

    private void Start()
    {
        startDistance = currentDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = this.GetComponent<CameraUtils>().GetRoundedDistance();
        if (startDistance == currentDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= moveCameraAfter)
            {
                this.transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);
            }
        }
        else
        {
            startDistance = currentDistance;
            currentTime = 0;
        }
    }
}
