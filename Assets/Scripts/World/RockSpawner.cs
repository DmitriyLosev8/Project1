using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private Rock _rockTempLate;
    [SerializeField] private Transform _rockSpawnPoint;
    
    private int _maxCountOfRocks = 1;
    private int _currentCountOfRocks = 0;

    private void OnEnable()
    {
        Player.CameInRockZone += OnPlayerInRockEventZone;
    }

    private void OnDisable()
    {
        Player.CameInRockZone -= OnPlayerInRockEventZone;
    }

    private void OnPlayerInRockEventZone()
    {
        if (_currentCountOfRocks < _maxCountOfRocks)
        {
            Instantiate(_rockTempLate, _rockSpawnPoint.transform.position, Quaternion.identity);
            _currentCountOfRocks++;
        }
    }
}
