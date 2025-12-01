using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadStartMenu()
    {
        //load the first scene in the build profile
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //load the scene named "LaserDefender"
        SceneManager.LoadScene("LaserDefender");
        //reset game session
        FindFirstObjectByType<GameSession>().ResetGameSession();
    }

    public void LoadGameOver()
    {
        //load the scene named "GameOver"
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        //quit the application
        Application.Quit();
        print("Quit Game");
        EditorApplication.isPlaying = false;
    }
}
