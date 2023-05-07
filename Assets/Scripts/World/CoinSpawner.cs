using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private Transform[] _coinSpawnPoints;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for(int i = 0; i < _coinSpawnPoints.Length; i++)
        {
            Instantiate(_coinTemplate, _coinSpawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
