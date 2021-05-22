using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Play_1_PlayerGame()
    {
        SceneManager.LoadScene("1PlayerMode");
    }
    
    public void Play_2_PlayerGame()
    {
        SceneManager.LoadScene("2PlayerMode");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
