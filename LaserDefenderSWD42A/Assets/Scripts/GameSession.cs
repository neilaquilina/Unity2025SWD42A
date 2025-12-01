using UnityEngine;

public class GameSession : MonoBehaviour
{

    int score = 0;

    void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int numberOfGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        //if there is more than one GameSession, destroy the last one created
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //add points to the current score
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    //get the current score
    public int GetScore()
    {
        return score;
    }

    public void ResetGameSession()
    {
        Destroy(gameObject);
    }
}
