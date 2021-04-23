using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils : MonoBehaviour
{
    public Camera objectCamera;

    public float GetCameraWidth()
    {
        float height = 2f * objectCamera.orthographicSize;
        return height * objectCamera.aspect;
    }

    public float GetRoundedDistance()
    {
        return Mathf.Round(transform.position.x);
    }
}
