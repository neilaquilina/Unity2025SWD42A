using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        //load the first scene in the build index
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //load the scene named "LaserDefender"
        SceneManager.LoadScene("LaserDefender");
    }

    public void LoadGameOver()
    {
        //load the scene named "GameOver"
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        //quit the application
        Application.Quit();
    }
}
