using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    private TextMeshPro text;

    public float timeUntilElementChange = 5;
    private float time = -1;
    void Start()
    {
        text = GetComponent<TextMeshPro>();

    }

    void Update()
    {
        if (time < 1)
        {
            time = timeUntilElementChange + 1;
        }
        else
        {
            time -= Time.deltaTime;
        }

        text.text = "Element Change: " + (int) time;
    }
}
