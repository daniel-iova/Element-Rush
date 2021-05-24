using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDistance : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshPro text;
    public Camera mainCamera;
    public GameObject[] players;

    private int noPlayers = 0;
    private float[] playerPositionsX;
    void Start()
    {
        text = GetComponent<TextMeshPro>();

        noPlayers = players.Length;
        playerPositionsX = new float[noPlayers];
        for (int i = 0; i < noPlayers; i++)
        {
            playerPositionsX[i] = players[i].transform.position.x;
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool changeDistance = true;
        for(int i = 0;i<noPlayers;i++)
        {
            if (players[i].transform.position.x <= playerPositionsX[i])
            {
                changeDistance = false;

            }
            else
                playerPositionsX[i] = players[i].transform.position.x;
        }
        if(changeDistance == true)
            text.text = $"Distance: {mainCamera.GetComponent<CameraUtils>().GetRoundedDistance()}";

    }
}
