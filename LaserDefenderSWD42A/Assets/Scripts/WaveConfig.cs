using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "Scriptable Objects/WaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    //path on which to move the enemy
    [SerializeField] List<Transform> pathPrefab;
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
        return pathPrefab;
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
