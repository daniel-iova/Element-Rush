using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupCounter : MonoBehaviour
{
    private TextMeshPro text;

    public float timeUntilElementChange = 10;
    private float elapsedTime;
    public Player[] players;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        elapsedTime = timeUntilElementChange;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < 1)
        {
            //time = timeUntilElementChange + 1;
            elapsedTime = timeUntilElementChange;
            foreach (Player p in players)
            {
                p.SetInvincibleState(false);
            }
        }
        else
        {
            elapsedTime -= Time.deltaTime;
        }

        text.text = "Invincibility wears off in: " + (int)elapsedTime;
    }
}
