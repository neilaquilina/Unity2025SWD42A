using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    TMP_Text healthText;
    Player player;
    Slider healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //link healthText to the TMP_Text component
        healthText = GetComponent<TMP_Text>();

        //link player to the first Player object found
        player = FindFirstObjectByType<Player>();

        //link healthBar to the Slider component
        healthBar = FindFirstObjectByType<Slider>();
        healthBar.maxValue = player.GetHealth();

    }

    // Update is called once per frame
    void Update()
    {
        //update the healthText to show the current health
        healthText.text = player.GetHealth().ToString();

        //update the healthBar to show the current health
        healthBar.value = player.GetHealth();

        //update the healthBar colour based on current health
        //50% health = yellow, 20% health = red, above 50% health = green   

    }
}
