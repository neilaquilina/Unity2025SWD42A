using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "Scriptable Objects/WaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    //path on which to move the enemy
    [SerializeField] GameObject pathPrefab;
    //delay before spawning the next enemy
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //number of enemies to spawn in this wave
    [SerializeField] int numberOfEnemies = 5;
    //speed at which the enemy moves
    [SerializeField] float enemyMoveSpeed = 2f;

    //encapsulate numberOfEnemies
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetPathPrefab()
    {
        List <Transform> waveWaypoints = new List<Transform>();

        //access the Path prefab and get all its child transforms
        foreach (Transform waypoint in pathPrefab.transform)
        {
            //add each waypoint to the list
            waveWaypoints.Add(waypoint);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    


}
