using UnityEngine;

public class RotatingCube : MonoBehaviour
{

    void Start()
    {
        //adjust the code so that the increment and decrement have limits from 5 to 200

        print("RotatingCube script has started.");
    }

    /// The rotation speed in degrees per second.
    /// Adjust this value to change how fast the cube rotates.
    /// SerializeField makes the field editable in the Unity Inspector.
    [SerializeField] float rotationSpeed = 50f;

    [SerializeField] float speedIncrement = 10f;

    // Update is called once per frame
    void Update()
    {
        // Check for up arrow key press to increase rotation speed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotationSpeed += speedIncrement;
            Debug.Log("Current rotation speed: " + rotationSpeed);
        }

        // Check for down arrow key press to decrease rotation speed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotationSpeed -= speedIncrement;
            Debug.Log("Current rotation speed: " + rotationSpeed);
        }

        // Rotate the object around the Y-axis (up vector) at the specified speed.
        // Multiply by Time.deltaTime to make rotation frame-rate independent.
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
