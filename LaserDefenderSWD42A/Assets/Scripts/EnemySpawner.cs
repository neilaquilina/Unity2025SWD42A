using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;
    
    [SerializeField] int startingWave = 0;

    [SerializeField] bool looping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        WaveConfig currentWave = waveConfigList[startingWave];
        do
        {
            
            yield return StartCoroutine(SpawnAllWaves());
        }
        //when coroutine ends, check if looping is true
        while (looping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAllWaves()
    {
        //spawn all waves in the wave configuration list
        foreach (WaveConfig wave in waveConfigList)
        {
            //wait until all enemies in the current wave are spawned
            //before starting the next wave
            yield return StartCoroutine(SpawnAllEnemiesInWave(wave));
        }
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

            //set the wave configuration for the newly spawned enemy
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            //wait for the specified time before spawning the next enemy
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
