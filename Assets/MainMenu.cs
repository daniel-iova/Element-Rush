using Assets.Scripts.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Play_1_PlayerGame()
    {
        // set scene config to 1p
        ConfigFileUtil.UpdateMode(1);
        SceneManager.LoadScene("1PlayerMode");
    }
     
    public void Play_2_PlayerGame()
    {
        // set scene config to 2p
        ConfigFileUtil.UpdateMode(2);
        SceneManager.LoadScene("2PlayerMode");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
