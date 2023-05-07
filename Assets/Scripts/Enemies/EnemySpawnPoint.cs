using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private int _enemyId;    

    public int EnemyId=> _enemyId;
}
