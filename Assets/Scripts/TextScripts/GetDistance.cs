using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDistance : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshPro text;
    public Camera mainCamera;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Distance: {mainCamera.GetComponent<CameraUtils>().GetRoundedDistance()}";
    }
}
