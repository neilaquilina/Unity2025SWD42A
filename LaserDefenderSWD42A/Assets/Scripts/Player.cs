using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    /// <summary>
    /// The movement speed of the player.
    /// Adjust this value to change how fast the player moves.
    /// </summary>
    [SerializeField] float speed = 10f;

    [SerializeField] GameObject laserPrefab;

    IEnumerator shootingCoroutine;

    [SerializeField] float extraY = 0.5f;

    Vector2 playerPosition;

    // Get the main camera
    Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Get the main camera
        mainCamera = Camera.main;
        //save the shooting coroutine
        shootingCoroutine = ShootContinuously();

    }

    void Move()
    {
        // Get horizontal input (left/right arrow keys or A/D)
        float horizontal = Input.GetAxis("Horizontal");

        // Get vertical input (up/down arrow keys or W/S)
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement vector (X and Y axes, Z=0 for 2D)
        Vector2 movement = new Vector2(horizontal, vertical) * speed * Time.deltaTime;

        // Apply the movement to the player's transform
        transform.Translate(movement);
    }

    /// <summary>
    /// Handles screen wrapping for the player.
    /// If the player goes off one side of the screen, they appear on the opposite side.
    /// </summary>
    private void WrapPlayer()
    {
        // Convert screen coordinates to world coordinates
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check horizontal wrapping
        if (viewportPosition.x > 1f)
        {
            viewportPosition.x = 0f;
        }
        else if (viewportPosition.x < 0f)
        {
            viewportPosition.x = 1f;
        }

        // Check vertical wrapping
        if (viewportPosition.y > 1f)
        {
            viewportPosition.y = 0f;
        }
        else if (viewportPosition.y < 0f)
        {
            viewportPosition.y = 1f;
        }

        // Convert back to world coordinates and apply
        transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);
    }

    /// <summary>
    /// Makes the camera follow the player by updating its position to match the player's.
    /// Maintains the camera's existing Z position for proper depth in 2D games.
    /// </summary>
    private void FollowPlayer()
    {
        // Set the camera's position to the player's position, keeping the camera's Z value
        Vector3 playerPosition = transform.position;
        mainCamera.transform.position = new Vector3(playerPosition.x, playerPosition.y, mainCamera.transform.position.z);
    }

    void ShootLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(shootingCoroutine);
        }
    
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(shootingCoroutine);
        }
    }

    IEnumerator ShootContinuously()
    {
        //loop until we stop the coroutine
        while (true)
        {
            //get the player's position
            playerPosition = transform.position;
            //add the extra to the y position
            playerPosition.y += extraY;
            // Instantiate the laser prefab at the player's position with no rotation
            GameObject laser = Instantiate(laserPrefab, playerPosition, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().linearVelocityY = 10f;

            //wait for 0.2 seconds before shooting again
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        WrapPlayer();
        ShootLaser();
       

    }
}


