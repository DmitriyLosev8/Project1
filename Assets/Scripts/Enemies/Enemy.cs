using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private EnemySpittle _enemySpittleTemplate;
    [SerializeField] private Transform _spittleSpawnPoint;
    [SerializeField] private float _delayOfSpit;
    [SerializeField] private int _id;

    private const string IsAttack = "IsAttack";

    private float _timeBetweenSpit = 5;
    private Animator _animator;

    public int Id => _id;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyAttackZone enemySpitZone))
            StartCoroutine(TryToSpit(enemySpitZone));
    }

    public void SetSpittleSpawnPointRotation(Quaternion direction)
    {
        _spittleSpawnPoint.transform.rotation = direction;
    }

    private IEnumerator TryToSpit(EnemyAttackZone enemySpitZone)
    {
        while (true)
        {
            if (enemySpitZone.IsEnemyNeedToSpit)
                Spit(enemySpitZone);
                
            _animator.SetBool(IsAttack, enemySpitZone.IsEnemyNeedToSpit);
            yield return null;  
        }
    }

    private void Spit(EnemyAttackZone enemySpitZone)
    {
        if (_timeBetweenSpit <= 0)
        {
            Instantiate(_enemySpittleTemplate, _spittleSpawnPoint.position, _spittleSpawnPoint.transform.rotation);
            _timeBetweenSpit = _delayOfSpit;
        }
        else
            _timeBetweenSpit -= Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Die();
    }

    private void Die()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
