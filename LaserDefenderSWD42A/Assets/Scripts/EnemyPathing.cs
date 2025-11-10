using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> waypointsList;

    WaveConfig waveConfig;

    // Index to track the current waypoint
    int waypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the list of waypoints from the wave configuration
        waypointsList = waveConfig.GetPathPrefab();
        //set the enemy's position to the first waypoint
        transform.position = waypointsList[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
    //set the wave configuration for this enemy
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
          waveConfig = waveConfigToSet;
    }

    void EnemyMove()
    {
        if (waypointIndex < waypointsList.Count)
        {
            //move the enemy towards the current waypoint
            var targetPosition = waypointsList[waypointIndex].transform.position;
            // Ensure z-axis is 0 for 2D movement
            targetPosition.z = 0f; 
            var movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
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
