using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    TMP_Text scoreText;
    GameSession gameSession;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //link scoreText to the TMP_Text component
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //link gameSession to the first GameSession object found
        gameSession = FindFirstObjectByType<GameSession>();

        //update the scoreText to show the current score
        scoreText.text = gameSession.GetScore().ToString();

    }
}
