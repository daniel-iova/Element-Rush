using Assets.Scripts.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils : MonoBehaviour
{
    public Camera objectCamera;

    private string playMode;

    void Start()
    {
    }

    public dynamic GetKeysForPlayerId(int id)
    {
        string mode = ConfigFileUtil.GetValue("mode").ToString();
        return ConfigFileUtil.GetValue(mode)[id];
    }

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
