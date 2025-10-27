using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypointsList;
    [SerializeField] float enemySpeed = 2f;
    // Index to track the current waypoint
    int waypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the enemy's position to the first waypoint
        transform.position = waypointsList[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if (waypointIndex < waypointsList.Count)
        {
            //move the enemy towards the current waypoint
            var targetPosition = waypointsList[waypointIndex].transform.position;
            // Ensure z-axis is 0 for 2D movement
            targetPosition.z = 0f; 
            var movementThisFrame = enemySpeed * Time.deltaTime;
            //move the enemy towards the target position at a constant speed
            transform.position = Vector2.MoveTowards(transform.position, 
                targetPosition, movementThisFrame);
            //check if the enemy has reached the waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            //destroy the enemy when it reaches the last waypoint
            Destroy(gameObject);
            
        }
        
        
    }
}
