using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;
    
    [SerializeField] int startingWave = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaveConfig currentWave = waveConfigList[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        //spawn enemies based on the wave configuration
        for (int enemyCount = 1; enemyCount <= waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            //instantiate enemy at the starting position of the path
            GameObject newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetPathPrefab()[0].transform.position,
                Quaternion.identity);
            //wait for the specified time before spawning the next enemy
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
