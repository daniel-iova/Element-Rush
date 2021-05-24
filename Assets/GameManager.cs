using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] gameObjects;
    bool gameHasEnded = false;

    public Text pointsText;
    public float restartDelay = 1f;
    public Camera mainCamera;

    public void GameOverSetup()
    {
        gameObject.SetActive(true);

        int noGameObjects = gameObjects.Length;
        for (int i = 0; i < noGameObjects; i++)
            gameObjects[i].SetActive(false);
        
        pointsText.text = "Distance: " + mainCamera.GetComponent<CameraUtils>().GetRoundedDistance();
    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
