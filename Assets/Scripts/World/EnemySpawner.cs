using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyTemplates;
    [SerializeField] private EnemySpawnPoint[] _spawnPoints;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {    
        Enemy enemyForSpawn;
        
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            for (int j = 0; j < _enemyTemplates.Length; j++)
            {
                if (_spawnPoints[i].EnemyId == _enemyTemplates[j].Id)
                {
                    enemyForSpawn = _enemyTemplates[j];
                    Instantiate(enemyForSpawn, _spawnPoints[i].transform.position, Quaternion.identity).GetComponent<Enemy>().SetSpittleSpawnPointRotation(_spawnPoints[i].transform.rotation);
                }
            }
        }
    }
}
